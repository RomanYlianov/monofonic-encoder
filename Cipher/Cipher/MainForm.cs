using Cipher.Model;
using System.Diagnostics;

namespace Cipher
{
    public partial class MainForm : Form
    {

        DatabaseManager manager;



        public MainForm()
        {
            InitializeComponent();

            manager = new DatabaseManager();

        }




        private async void Form1_Load(object sender, EventArgs e)
        {

            //add encodings
            encodingCmb.Items.Add("ASCII");
            encodingCmb.Items.Add("UTF-8");
            encodingCmb.Enabled = false;
            encodingCmb.SelectedIndex = 0;
            //other

            defaultRbtn.Checked = true;
            incrZeroRbtn.Checked = true;

            //set properties

            Properties.EncodingType = "ASCII";
            Properties.Order = OrderType.INCREASE_ZERO;
            Properties.AlgBasedData = AlgData.DEFAULT;
            Properties.ShowStatistic = false;


            mulKoefficient.Minimum = 1;
            mulKoefficient.Maximum = 10;
            learnModeAutoRbtn.Checked = true;


            await Task.Run(() => manager.CreateSession());

            if (Properties.MethodErrors.Count == 0)
            {
                string userId = Properties.UserId.ToString();
                logger.Text += "success create session " + Properties.UserId.ToString();
            }
            else
            {
                foreach (string msg in Properties.MethodErrors)
                {
                    logger.Text += "\n" + msg;
                }
            }
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {

            RadioButton rBtn = (RadioButton)sender;

            switch (rBtn.Name)
            {
                case "incrZeroRbtn":
                    Properties.Order = OrderType.INCREASE_ZERO;
                    break;
                case "incrDecrRbtn":
                    Properties.Order = OrderType.INCREASE_DECREASE;

                    break;
                case "decrZeroRbtn":
                    Properties.Order = OrderType.DECREASE_ZERO;
                    break;
                case "decrIncrRbtn":
                    Properties.Order = OrderType.DECREASE_INCREASE;
                    break;
            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmbBox = (ComboBox)sender;
            switch (cmbBox.Name)
            {

                case "encodingCmb":
                    Properties.EncodingType = cmbBox.Text;
                    break;
            }
        }

        private async void learn_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "text files (*.txt)|*txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {

                logger.Text = "";
                logger.Text += $"\n {GetCurrentDate()}| start learning on cusom text";
                Properties.LearningTextPath = ofd.FileName;

                AnimateProggressBar(true);

                await Task.Run(() => manager.Learning());

                MethodResultHandler();

                AnimateProggressBar(false);

            }

        }

        private async void encrypt_btn_Click(object sender, EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "text files (*.txt)|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                logger.Text = "";
                logger.Text += $"\n {GetCurrentDate()}| start encrypting";
                logger.Text += $"\n mode is {Properties.Order.ToString()}, encoding is {Properties.EncodingType}";
                Properties.DecryptFilePath = ofd.FileName;
                Properties.EncryptFilePath = GetCopyFileName(ofd.FileName);



                AnimateProggressBar(true);


                await Task.Run(() => manager.Encrypt());

                MethodResultHandler();


                AnimateProggressBar(false);

            }
        }

        private async void decrypt_btn_Click(object sender, EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "text files (*.txt)|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                logger.Text = "";
                logger.Text += $"\n {GetCurrentDate()}| start decrypting";
                logger.Text += $"\n mode is {Properties.Order.ToString()}, encoding is {Properties.EncodingType}";
                Properties.EncryptFilePath = ofd.FileName;
                Properties.DecryptFilePath = GetCopyFileName(ofd.FileName, false);


                AnimateProggressBar(true);

                await Task.Run(() => manager.Decrypt());

                MethodResultHandler();

                AnimateProggressBar(false);
            }

        }



        private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //MessageBox.Show("bye");

            //before closing



            await Task.Run(() => manager.DestroySession());


            if (Properties.MethodErrors.Count == 0)
            {
                logger.Text += "success destroy session " + Properties.UserId.ToString();
            }
            else
            {
                foreach (string msg in Properties.MethodErrors)
                {
                    logger.Text += "\n" + msg;
                }
            }


        }

        private void modeRbtn_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton btn = (RadioButton)sender;

            switch (btn.Name)
            {
                case "defaultRbtn":
                    {
                        setEnable(false);
                        Properties.AlgBasedData = AlgData.DEFAULT;

                    }
                    break;
                case "customRbtn":
                    {
                        setEnable(true);
                        Properties.AlgBasedData = AlgData.CUSTOM;
                    }
                    break;
            }
            void setEnable(bool f)
            {

                abc_btn.Enabled = f;
                learnGroupBox.Enabled = f;
            }
        }



        private void abc_btn_Click(object sender, EventArgs e)
        {
            ABCForm form = new ABCForm();
            form.ShowDialog();
            if (form.ABC != null)
            {
                Properties.ABC = form.ABC.ToString();

            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Properties.ShowStatistic = (symbolsStatistic.Checked);
        }

        private void MethodResultHandler()
        {
            if (Properties.MethodErrors.Count == 0)
            {
                logger.Text += "\ncompleted with result: OKAY";
            }
            else
            {
                logger.Text += "\ncompleted with result: FAIL\nerrors:";
                foreach (string msg in Properties.MethodErrors)
                {
                    logger.Text += "\n" + msg;
                }
            }
        }


        private void AnimateProggressBar(bool on)
        {
            if (on)
            {
                progressBar1.Style = ProgressBarStyle.Marquee;
                progressBar1.MarqueeAnimationSpeed = 30;
            }
            else
            {
                progressBar1.MarqueeAnimationSpeed = 0;
                progressBar1.Style = ProgressBarStyle.Blocks;
            }
        }

        private string GetCopyFileName(string path, bool isEncrypt = true)
        {
            if (isEncrypt)
            {
                return path.Substring(0, path.IndexOf(".txt")) + "_encrypt.txt";
            }
            else
            {
                return path.Substring(0, path.IndexOf(".txt")) + "_decrypt.txt";
            }

        }

        private void encodingCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            Properties.EncodingType = cmb.Text;

        }

        private string GetCurrentDate()
        {
            DateTime time = DateTime.Now;

            string date = time.Year + "/" + time.Month + "/" + time.Day + " " + time.Hour + ":" + time.Minute + ":" + time.Second;
            return date;
        }

        /* private async void button1_Click(object sender, EventArgs e)
         {
             MessageBox.Show(Properties.UserId.ToString());
         }*/

        private void nd_koeff_ValueChanged(object sender, EventArgs e)
        {
            Properties.MultiplyCoefficient = (int)mulKoefficient.Value;

        }

        private void learnModeRbtn_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rBtn = (RadioButton)sender;
            switch (rBtn.Name)
            {
                case "learnModeAutoRbtn":
                    mulKoefficient.Enabled = false;
                    Properties.Mode = LearnMode.AUTO;
                    break;
                case "learnModeManualRbtn":
                    mulKoefficient.Enabled = true;
                    Properties.Mode = LearnMode.MANUAL;
                    break;
            }
        }


    }
}