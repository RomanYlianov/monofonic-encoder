using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cipher.Model
{
    internal class Properties
    {

        private static string DefaultABC = "абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯabcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static Guid? UserId { get; set; }

        public static bool ShowStatistic { get; set; }

        public static int MultiplyCoefficient { get; set; }

        public static LearnMode Mode { get; set; }


        private static string _ABC = DefaultABC;

        public static string ABC 
        { 
            get
            {
                return _ABC;
            }
            set
            {
                if (!string.IsNullOrEmpty(value)) 
                {
                    _ABC = value;
                }
            }
        
        } 

        public static bool IsLearned 
        {
            get
            {
                return !string.IsNullOrEmpty(LearningTextPath);
            }
        }

        public static AlgData AlgBasedData { get; set; }

       // public static bool IsDefaultABC { get { return ABC.Equals(DefaultABC); } }

        public static OrderType Order { get; set; }

        public static string EncodingType { get; set; }

        public static string EncryptFilePath { get; set; }

        public static string DecryptFilePath { get; set; }

        public static string LearningTextPath { get; set; }

        public static List<string> MethodErrors = new List<string>();

    }

    enum OrderType
    {
        INCREASE_ZERO, INCREASE_DECREASE, DECREASE_ZERO, DECREASE_INCREASE
    }

    enum AlgData
    {
        DEFAULT, CUSTOM
    }

    enum LearnMode
    {
        AUTO, MANUAL
    }

}
