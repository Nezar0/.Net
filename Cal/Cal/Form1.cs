using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Cal
{
    public partial class Form1 : Form
    {
        private float a, m, u;
        private int count;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void button_Click(object sender, EventArgs e)
        {
            {
                if (result.Text == "0" || (result.Text!="" && m != 0))
                {
                    result.Clear();
                    label1.Text = "";
                    m = 0;
                }
                Button b = (Button)sender;
                result.Text = result.Text + b.Text;
                    if (b.Text == ",")
                    {
                        if (result.Text == "0" || result.Text == ",")
                        {
                            result.Clear();
                            result.Text = "0,";                                     
                        }
                    btnDot.Enabled = false;
                }
                u = float.Parse(result.Text);
            }
        }


        private void btnCalc(object sender, EventArgs e)
        {
            Button n = (Button)sender;
            switch (n.Text)
            {
                case "+":
                    if (result.Text != "")
                    {
                        a = float.Parse(result.Text);
                        label1.Text = a.ToString() + n.Text;
                        result.Clear();
                        btnDot.Enabled = true;
                        count = 1;  

                    }
                break;
                case "-":
                    if (result.Text != "")
                    {
                        a = float.Parse(result.Text);
                        label1.Text = a.ToString() + n.Text;
                        btnDot.Enabled = true;
                        result.Clear();                      
                        count = 2;
                    }
                    break;
                case "*":
                    if (result.Text != "")
                    {
                        a = float.Parse(result.Text);
                        label1.Text = a.ToString() + n.Text;
                        btnDot.Enabled = true;
                        result.Clear();
                        count = 3;
                    }
                    break;
                case "/":
                    if (result.Text != "")
                    {
                        a = float.Parse(result.Text);
                        label1.Text = a.ToString() + n.Text;
                        btnDot.Enabled = true;
                        result.Clear();                      
                        count = 4;
                    }
                    break;
                case "C":
                    result.Text = "0";
                    label1.Text = "";
                    a = u = 0;
                    btnDot.Enabled = true;
                    break;
                case "CE":
                    if (result.Text != "")
                    {
                        result.Text = result.Text.Substring(0, result.Text.Length - 1);
                        Regex regex = new Regex(@"(,)");
                        MatchCollection matches = regex.Matches(result.Text);
                        if (matches.Count == 0)
                        {
                            btnDot.Enabled = true;
                        }
                    }
                    break;
                case "=":
                    if (result.Text != "")
                    {                      
                        switch (count)
                        {
                            case 1:
                                m = a + u;
                                label1.Text = a.ToString() + "+" + u.ToString() + "=";
                                a = m;
                                result.Text = m.ToString();
                                btnDot.Enabled = true;
                                break;

                            case 2:
                                m = a - u;
                                label1.Text = a.ToString() + "-" + u.ToString() + "=";
                                a = m;
                                result.Text = m.ToString();
                                btnDot.Enabled = true;
                                break;

                            case 3:
                                m = a * u;
                                label1.Text = a.ToString() + "*" + u.ToString() + "=";
                                a = m;
                                result.Text = m.ToString();
                                btnDot.Enabled = true;
                                break;

                            case 4:
                                m = a / u;
                                label1.Text = a.ToString() + "/" + u.ToString() + "=";
                                a = m;
                                result.Text = m.ToString();
                                btnDot.Enabled = true;
                                break;
                        }
                    }
                    break;
            }
        }
    }
}