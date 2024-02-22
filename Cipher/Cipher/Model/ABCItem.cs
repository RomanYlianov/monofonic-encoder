using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cipher.Model
{
    internal class ABCItem
    {

        public int Id { get; set; }

        public int Code { get; set; }

        public long CountInText { get; set; }

        public int CurrentIndex { get; set; }

        public double Freq { get; set; }

        public List<int> ReplaceCodes { get; set; } = new List<int>();

        public ABCItem()
        {
            
        }

        public ABCItem(int id, int code, double freq)
        {
            this.Id = id;
            this.Code = code;
            this.Freq = freq;
        }

    }
}
