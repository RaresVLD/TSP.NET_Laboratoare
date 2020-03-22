using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace TSPNET_LAB2
{
    public partial class Calculator : Form
    {
        private TextBox txtBox = new TextBox();
        public Calculator()
        {
            InitializeComponent(); 
            KeyPreview = true;
            KeyPress +=
                new KeyPressEventHandler(Calculator_KeyPress);
        }
        void Calculator_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox1.Text += e.KeyChar.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text += "3";
        }
        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += "4";
        }
        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text += "5";
        }
        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text += "6";
        }
        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += "7";
        }
        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += "8";
        }
        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text += "9";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text += "+";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text += "*";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text += "-";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text += "/";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text += ".";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox1.Text += "0";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            var v = dt.Compute(textBox1.Text, "");
            textBox1.Text = v.ToString();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (textBox1.Text[textBox1.TextLength - 1] == ')')
            {
                int i = 1;
                while (true)
                {
                    if (textBox1.Text[textBox1.TextLength - i] == '(')
                    {
                        var theString = textBox1.Text;
                        var aStringBuilder = new StringBuilder(theString);
                        aStringBuilder.Remove(textBox1.TextLength - i, 2);
                        aStringBuilder.Remove(aStringBuilder.Length - 1, 1);
                        theString = aStringBuilder.ToString();
                        textBox1.Text = theString;
                        break;
                    }
                    i++;
                }
            }
            else
            {
                int i = 1;
                while (true)
                {

                    if(i == textBox1.TextLength)
                    {
                        if(textBox1.Text[textBox1.TextLength - 1] == ')')
                        {
                            var theString = textBox1.Text;
                            var aStringBuilder = new StringBuilder(theString);
                            aStringBuilder.Remove(textBox1.TextLength - i, 2);
                            aStringBuilder.Remove(aStringBuilder.Length - 1, 1);
                            theString = aStringBuilder.ToString();
                            textBox1.Text = theString;
                            break;
                        }
                        else
                        {
                            var theString = textBox1.Text;
                            var aStringBuilder = new StringBuilder(theString);
                            aStringBuilder.Insert(0, "(-");
                            aStringBuilder.Insert(aStringBuilder.Length, ")");
                            theString = aStringBuilder.ToString();
                            textBox1.Text = theString;
                        }

                        break;
                    }

                    if (textBox1.Text[textBox1.TextLength - i] == '+' ||
                        textBox1.Text[textBox1.TextLength - i] == '-' ||
                        textBox1.Text[textBox1.TextLength - i] == '/' ||
                        textBox1.Text[textBox1.TextLength - i] == '*')
                    {

                        var theString = textBox1.Text;
                        var aStringBuilder = new StringBuilder(theString);
                        aStringBuilder.Insert(textBox1.TextLength - i + 1, "(-");
                        aStringBuilder.Insert(aStringBuilder.Length, ")");
                        theString = aStringBuilder.ToString();
                        textBox1.Text = theString;

                        break;
                    }
                    i++;
                }
            }
            /*if (textBox1.Text[textBox1.Text.Length - 1].Equals(')'))
            {

                int i = 1;
                while (true)
                {
                    if (
                        textBox1.Text[textBox1.Text.Length - i].Equals('-') ||
                        textBox1.Text[textBox1.Text.Length - i].Equals('+') ||
                        textBox1.Text[textBox1.Text.Length - i].Equals('/') ||
                        textBox1.Text[textBox1.Text.Length - i].Equals('*')
                    )
                    {
                        break;
                    }
                    i++;
                }
                var theString = textBox1.Text;
                var aStringBuilder = new StringBuilder(theString);
                aStringBuilder.Remove(aStringBuilder.Length - 1, 1);
                aStringBuilder.Remove(aStringBuilder.Length - 1 - i, 2);
                theString = aStringBuilder.ToString();
                textBox1.Text = theString;

            }
            else
            {
                int i = 1;
                while (true)
                {
                    if (
                        textBox1.Text[textBox1.Text.Length - i].Equals('-') ||
                        textBox1.Text[textBox1.Text.Length - i].Equals('+') ||
                        textBox1.Text[textBox1.Text.Length - i].Equals('/') ||
                        textBox1.Text[textBox1.Text.Length - i].Equals('*')
                    )
                    {
                        break;
                    }
                    i++;
                }
                var theString = textBox1.Text;
                var aStringBuilder = new StringBuilder(theString);
                aStringBuilder.Insert(i, "(-");
                aStringBuilder.Insert(aStringBuilder.Length, ")");
                theString = aStringBuilder.ToString();
                textBox1.Text = theString;
            }*/

        }

        private void button18_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
    }
}
