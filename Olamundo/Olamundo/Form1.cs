using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Olamundo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i <= 100; i++)
            {


                if (i % 3 == 0 && i % 5 == 0)
                {
                    tb_numeros.Text= Convert.ToString(i + " FizzBuzz");
                }
                else if (i % 3 == 0)
                {
                    tb_numeros.Text = Convert.ToString(i + " Fizz");
                }
                else if (i % 5 == 0)
                {
                    tb_numeros.Text = Convert.ToString(i + " Buzz");
                }

                else
                {
                    tb_numeros.Text = Convert.ToString(i);
                }

            }
        }
    }
}
