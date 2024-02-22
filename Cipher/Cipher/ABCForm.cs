using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cipher
{
    public partial class ABCForm : Form
    {

        public string? ABC { get; set; } = null;


        public ABCForm()
        {
            InitializeComponent();
        }

      

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Name.Equals("ok_btn"))
            {
                string temp = richTextBox1.Text;
                ABC = temp;
            }
            this.Close();
        }
    }
}
