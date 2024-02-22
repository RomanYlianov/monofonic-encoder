using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cipher.Model
{
    internal class DatabaseManager
    {

        string ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=resources;Trusted_Connection=True;";

       

        int BufferSize = 512;

        int blockSize = 4;

        int decodedSymbolCode = -1;


        List<ABCItem> words;


        public async Task Learning()
        {

            Properties.MethodErrors = new List<string>();

            string path = Properties.LearningTextPath;

            string abc = Properties.ABC;

            words = new List<ABCItem>();

            long countAll = 0;

            using (StreamReader reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    char[] buffer = new char[BufferSize];
                    int factCount = await reader.ReadAsync(buffer);
                    for (int i = 0; i < factCount; i++)
                    {
                        char c = buffer[i];
                        if (abc.Contains(c))
                        {
                            bool flag = false;
                            for (int j = 0; j < words.Count; j++)
                            {
                                if (words[j].Code.Equals((int)c))
                                {
                                    words[j].CountInText++;
                                    flag = true;
                                    break;
                                }
                            }
                            if (!flag)
                            {
                                ABCItem element = new ABCItem();
                                element.Code = (int)c;
                                element.CountInText = 1;
                                words.Add(element);
                            }
                            countAll++;
                        }
                    }
                }
            }

            //calculate replace indexes

            words.Sort((a, b) => a.Freq.CompareTo(b.Freq));

            int replaceCount = words.Count;

            for (int i=0; i<words.Count; i++)
            {
                for (int j=0; j<replaceCount; j++)
                {
                    int code = i * replaceCount + j;
                    words[i].ReplaceCodes.Add(code);
                }
            }

            //double minFreq = double.MaxValue, maxFreq = double.MinValue;

            //for (int i = 0; i < words.Count; i++)
            //{
            //    ABCItem item = words.ElementAt(i);
            //    item.Freq = (item.CountInText * 1.0) / countAll;
            //    if (item.Freq < minFreq)
            //    {
            //        minFreq = item.Freq;
            //    }
            //    if (item.Freq > maxFreq)
            //    {
            //        maxFreq = item.Freq;
            //    }
            //}

            //шаг для уменьшения количества слов в замене
            /*double decreaseStep = (maxFreq - minFreq) / words.Count;

            words.Sort((a, b) => a.Freq.CompareTo(b.Freq));

            int replaceCount = words.Count;

            double curFreq = maxFreq;

            for (int i = words.Count - 1; i >= 0; i--)
            {
                while (curFreq > words[i].Freq)
                {
                    curFreq -= decreaseStep;
                    replaceCount--;
                }
                for (int j = 0; j < replaceCount; j++)
                {
                    int code = i * replaceCount + j;
                    words[i].ReplaceCodes.Add(code);
                }
            }*/

            int t = 0;

            //saving to database

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {

                string userId = Properties.UserId.Value.ToString();

                try
                {
                    await connection.OpenAsync();

                    foreach (ABCItem item in words)
                    {
                        string query = $"insert into symbols (code, freq, encoding_id, session_id) values ({item.Code}, {item.Freq}, (select id from encodings where name='{Properties.EncodingType}'),'{userId}'); SELECT SCOPE_IDENTITY();";

                        SqlCommand cmd = new SqlCommand(query, connection);

                       

                        int insertedId = Convert.ToInt32(await cmd.ExecuteScalarAsync());



                        foreach (int code in item.ReplaceCodes)
                        {
                            query = $"insert into symbol_replaces (symbol_id, replace_code) values ({insertedId}, {code})";
                            cmd = new SqlCommand(query, connection);
                            await cmd.ExecuteNonQueryAsync();
                        }
                    }
                }
                catch (SqlException ex)
                {
                    string msg = "sql error: " + ex.Message;
                    Properties.MethodErrors.Add(msg);
                    
                   
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        await connection.CloseAsync();
                    }
                }
            }

        }

        //decrypt - original, encrypt - goal
        public async Task Encrypt()
        {
            Properties.MethodErrors = new List<string>();
            try
            {
                await Load();


                bool isIncrease = InitializeOrderMode();

                using (StreamWriter writer = new StreamWriter(Properties.EncryptFilePath))
                {

                    using (StreamReader reader = new StreamReader(Properties.DecryptFilePath))
                    {
                        while (!reader.EndOfStream)
                        {
                            char[] buffer = new char[BufferSize];

                            int factCount = await reader.ReadAsync(buffer);

                            for (int i = 0; i < factCount; i++)
                            {
                                char symbol = buffer[i];


                                string temp = "";

                                ABCItem item = new ABCItem();

                                if (Properties.ABC.Contains(symbol))
                                {
                                    item = words.Where(w => w.Code == (int)symbol).FirstOrDefault(); ;

                                    if (item != null)
                                    {
                                        temp = FormReplaceCode(item.ReplaceCodes[item.CurrentIndex]);

                                        switch (Properties.Order)
                                        {
                                            case OrderType.INCREASE_ZERO:

                                                CalculateSingleIndex();
                                                break;
                                            case OrderType.INCREASE_DECREASE:
                                                CalculateTwoIndex();
                                                break;
                                            case OrderType.DECREASE_ZERO:
                                                CalculateSingleIndex();

                                                break;
                                            case OrderType.DECREASE_INCREASE:
                                                CalculateTwoIndex();
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        string msg = "symbol " + symbol + " was not contains in learning text";
                                        throw new ArgumentException(msg);

                                    }



                                    void CalculateTwoIndex()
                                    {

                                        if (isIncrease)
                                        {
                                            item.CurrentIndex = item.CurrentIndex + 1 == item.ReplaceCodes.Count ? 0 : item.CurrentIndex + 1;
                                        }
                                        else
                                        {
                                            item.CurrentIndex = item.CurrentIndex - 1 == 0 ? item.ReplaceCodes.Count - 1 : item.CurrentIndex - 1;
                                        }
                                        if (item.CurrentIndex == item.ReplaceCodes.Count - 1)
                                        {
                                            isIncrease = false;
                                        }
                                        if (item.CurrentIndex == 0)
                                        {
                                            isIncrease = true;
                                        }
                                    }
                                    void CalculateSingleIndex()
                                    {
                                        if (isIncrease)
                                        {
                                            item.CurrentIndex = item.CurrentIndex + 1 == item.ReplaceCodes.Count ? 0 : item.CurrentIndex + 1;
                                        }
                                        else
                                        {
                                            item.CurrentIndex = item.CurrentIndex - 1 == 0 ? item.ReplaceCodes.Count - 1 : item.CurrentIndex - 1;
                                        }
                                    }

                                }
                                else
                                {

                                    temp = FormatNonABCSymbol(symbol);
                                }

                                await writer.WriteAsync(temp);

                            }

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                string msg = "exception occurred " + ex.Message;

                Properties.MethodErrors.Add(msg);
            }
           

            bool InitializeOrderMode()
            {
                bool res = false;

                switch (Properties.Order)
                {
                    case OrderType.INCREASE_ZERO:
                    case OrderType.INCREASE_DECREASE:
                        res = true;
                        break;
                    case OrderType.DECREASE_ZERO:
                    case OrderType.DECREASE_INCREASE:
                        res = false;
                        break;
                }
                return res;
            }

            string FormReplaceCode(int code)
            {
                string result = code.ToString();
                while (result.Length < blockSize)
                {
                    result = "0" + result;
                }

                return result;
            }

            string FormatNonABCSymbol(char symbol)
            {
                string result = symbol.ToString();

                while (result.Length < blockSize)
                {
                    result = "%" + result;
                }

                return result;
            }


            
            
        }

        

        //encrypt - original, decrypt - goal
        public async Task Decrypt()
        {
            Properties.MethodErrors = new List<string>();

            try
            {

                await Load();

                using (StreamWriter writer = new StreamWriter(Properties.DecryptFilePath))
                {
                    using (StreamReader reader = new StreamReader(Properties.EncryptFilePath))
                    {
                        while (!reader.EndOfStream)
                        {
                            char[] buffer = new char[blockSize];

                            int factCount = await reader.ReadAsync(buffer);

                            if (factCount == blockSize)
                            {

                                int code = -1;

                                string decoded = "";

                                foreach (char c in buffer)
                                {
                                    decoded += c;
                                }

                                if (int.TryParse(decoded, out code))
                                {
                                    await GetSymboilByReplaceCode(code);

                                    if (decodedSymbolCode >= 0)
                                    {
                                        decoded = Convert.ToChar(decodedSymbolCode).ToString();
                                    }
                                    else
                                    {
                                        throw new ArgumentException("code must be positive");
                                    }

                                }

                                decoded = decoded.Replace("%", "");

                                await writer.WriteAsync(decoded);
                            }
                            else
                            {

                                throw new ArgumentException("count of block must be equals to block size");
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = "exception ocurred " + ex.Message;
                Properties.MethodErrors.Add(msg);
            }

        }

        //$"select code from symbols where id = (select symbol_id from symbol_replaces where replace_code = {code})";
        private async Task GetSymboilByReplaceCode(int code)
        {
            decodedSymbolCode = -1;
            List<int> symbolIds = new List<int>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    await connection.OpenAsync();

                    string query = $"select symbol_id from symbol_replaces where replace_code = {code}";

                   

                    SqlCommand cmd = new SqlCommand(query, connection);

                    SqlDataReader reader = await cmd.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        int tmp = reader.GetInt32(0);
                        symbolIds.Add(tmp);
                    }

                    reader.Close();
                                          

                }
                catch (SqlException ex)
                {
                    string msg = "sql error: " + ex.Message;
                    Properties.MethodErrors.Add(msg);
                  
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        await connection.CloseAsync();
                    }
                }
            }

            if (symbolIds.Count > 0)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    try
                    {
                        await connection.OpenAsync();

                        foreach (int sId in symbolIds)
                        {
                            string query = $"select code from symbols where id={sId} and session_id#1#";

                            switch (Properties.AlgBasedData)
                            {
                                case AlgData.DEFAULT:
                                    query = query.Replace("#1#", " is null");
                                    break;
                                case AlgData.CUSTOM:
                                    query = query.Replace("#1#", "='" + Properties.UserId + "'");
                                    break;
                            }

                            SqlCommand cmd = new SqlCommand(query, connection);

                            SqlDataReader reader = await cmd.ExecuteReaderAsync();

                            if (await reader.ReadAsync())
                            {
                                decodedSymbolCode = reader.GetInt32(0);
                                break;
                            }
                            reader.Close();

                        }



                    }
                    catch (SqlException ex)
                    {
                        string msg = "sql error: " + ex.Message;
                        Properties.MethodErrors.Add(msg);

                    }
                    finally
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            await connection.CloseAsync();
                        }
                    }
                }
            }
            else
            {
                throw new ArgumentException("symbol with code " + code + " was not found");
            }

           

        }

        private async Task Load()
        {

            words = new List<ABCItem>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {

                    await connection.OpenAsync();

                    string request = "select id, code, freq from symbols where session_id#1# and encoding_id=(select id from encodings where name='#2#')";


                    switch (Properties.AlgBasedData)
                    {
                        case AlgData.DEFAULT:
                            request = request.Replace("#1#", " is null");
                            break;
                        case AlgData.CUSTOM:
                            {
                                request = request.Replace("#1#", $"='{Properties.UserId.ToString()}'");
                                if (Properties.IsLearned)
                                {

                                }
                                else
                                {
                                    throw new ArgumentException("you must learn system on text before using \"CUSTOM\" method");
                                }


                            }
                            
                            break;
                    }

                
                    request = request.Replace("#2#", Properties.EncodingType);

                    SqlCommand cmd = new SqlCommand(request, connection);

                    SqlDataReader reader = await cmd.ExecuteReaderAsync();

                    while ( await reader.ReadAsync())
                    {
                        int id = reader.GetInt32(0);

                        int code = reader.GetInt32(1);

                        double freq = reader.GetDouble(2);

                        ABCItem item = new ABCItem(id, code, freq);                       
                       
                        words.Add(item);


                    }

                    await reader.CloseAsync();




                }
                catch (SqlException ex)
                {
                    string msg = "sql error: " + ex.Message;
                    Properties.MethodErrors.Add(msg);
                }
                
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        await connection.CloseAsync();
                    }
                }

               
            }
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
               
                try
                {
                    await connection.OpenAsync();

                    for (int i=0; i<words.Count; i++)
                    {
                        ABCItem item = words[i];
                        List<int> replaceCodes = new List<int>();

                        string request = "select replace_code from symbol_replaces where symbol_id=" + item.Id.ToString();

                        SqlCommand cmd = new SqlCommand(request, connection);

                        SqlDataReader reader = await cmd.ExecuteReaderAsync();

                        while (await reader.ReadAsync())
                        {
                            int rcode = reader.GetInt32(0);
                            replaceCodes.Add(rcode);                            
                        }

                        switch (Properties.Order)
                        {
                            case OrderType.INCREASE_ZERO:
                            case OrderType.INCREASE_DECREASE:
                                item.CurrentIndex = 0;
                                break;
                            case OrderType.DECREASE_ZERO:
                            case OrderType.DECREASE_INCREASE:
                                item.CurrentIndex = replaceCodes.Count - 1;
                                break;
                        }

                        item.ReplaceCodes = replaceCodes;

                        await reader.CloseAsync();
                    }
                    

                }
                catch (SqlException ex)
                {
                    string msg = "sql error: " + ex.Message;
                    Properties.MethodErrors.Add(msg);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        await connection.CloseAsync();
                    }

                }
                
            }      

        }


        /// <summary>
        /// russian language https://dpva.ru/netcat_files/Image/GudeAlhabeth/DPVA_FrequencyRuLetters.jpg
        /// english language http://practicalcryptography.com/cryptanalysis/letter-frequencies-various-languages/english-letter-frequencies/
        /// </summary>
        /// <returns></returns>

   

        public async Task CreateSession()
        {
            Properties.MethodErrors = new List<string>();
           
            Guid id = Guid.NewGuid();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    SqlCommand cmd = new SqlCommand($"insert into user_sessions (id) values ('{id}')", connection);
                
                    if (await cmd.ExecuteNonQueryAsync() > 0)
                    {
                       
                        Properties.UserId = id;
                    }
                    else
                    {
                        Properties.MethodErrors.Add("failed to create session " + Properties.UserId.ToString());
                    }
                }
                catch (SqlException ex)
                {
                    string msg = "sql error: " + ex.Message;
                    Properties.MethodErrors.Add(msg);
                }
                finally
                {
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        await connection.CloseAsync();
                    }
                }
            }
           
        }

        public async Task DestroySession()
        {

            Properties.MethodErrors = new List<string>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    if (Properties.UserId != null)
                    {

                    }

                    SqlCommand cmd = new SqlCommand($"delete from user_sessions where id='{Properties.UserId.Value.ToString()}'", connection);

                    if (await cmd.ExecuteNonQueryAsync() == 0)
                    {
                        Properties.MethodErrors.Add("failed to destroy session " + Properties.UserId.ToString());
                       
                    }
                }
                catch (SqlException ex)
                {
                    string msg = "sql error: " + ex.Message;
                    Properties.MethodErrors.Add(msg);
                   
                }
                finally
                {
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        await connection.CloseAsync();
                    }
                }
            }

        }

    }
}
