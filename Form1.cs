using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Треугольник
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static public string CheckTriangle(int A, int B, int C)
        {
            List<int> sides = new List<int>() { A, B, C };

            if (sides.Any(el => el <= 0) || A + B < C || A + C < B || C + B < A)
            {
                MessageBox.Show("Введены неправильные данные!");
                return "";
            }

            if (A == B && A == C) return "Равносторонний";

            sides.Sort();

            if (sides[2] == sides[1] || sides[0] == sides[1]) return "Равнобедренный";

            return "Разносторонний";
        }

        static public string CheckSquare(int a, int b, int c)
        {
            double p = (Convert.ToDouble(a) + Convert.ToDouble(b) + Convert.ToDouble(c)) / 2;
            return Convert.ToString(Math.Round(Math.Sqrt(p * ((p - a) * (p - b) * (p - c))), 3));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a, b, c;
            if (int.TryParse(textBox1.Text, out a) && int.TryParse(textBox2.Text, out b) && int.TryParse(textBox3.Text, out c))
            {
                label4.Text = "Площадь\n" + CheckSquare(a, b, c);
                label5.Text = "Вид треугольника\n" + CheckTriangle(a, b, c);
            }
            else
            {
                MessageBox.Show("Введены неправильные данные!");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";

            }
        }
    }
}
