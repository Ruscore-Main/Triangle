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

            if (A == B && A == C) return "Равносторонний";

            sides.Sort();

            if (sides[2] == sides[1] || sides[0] == sides[1]) return "Равнобедренный";

            return "Разносторонний";
        }

        static public double CheckSquare(int A, int B, int C)
        {

            double
                a = Convert.ToDouble(A),
                b = Convert.ToDouble(B),
                c = Convert.ToDouble(C);

            double p = (Convert.ToDouble(a) + Convert.ToDouble(b) + Convert.ToDouble(c)) / 2;
            return Math.Round(Math.Sqrt(p * ((p - a) * (p - b) * (p - c))), 3);
        }

        static public string CheckAngle (int A, int B, int C)
        {
            double
                a = Convert.ToDouble(A),
                b = Convert.ToDouble(B),
                c = Convert.ToDouble(C);

            double
                cos_a = (a * a + c * c - b * b) / (2 * a * c),
                cos_b = (a * a + b * b - c * c) / (2 * a * b),
                cos_c = (b * b + c * c - a * a) / (2 * c * b);

            List<double> Angles = new List<double> { Math.Round(Math.Acos(cos_a) * 57.2958), Math.Round(Math.Acos(cos_b) * 57.2958), Math.Round(Math.Acos(cos_c) * 57.2958) };


            if (Angles.Any(angle => angle == 90)) return"Прямоугольный";
            else if (Angles.Any(angle => angle > 90)) return "Тупоугольный";
            return "Остроугольный";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a, b, c;
            if (int.TryParse(textBox1.Text, out a) && int.TryParse(textBox2.Text, out b) && int.TryParse(textBox3.Text, out c))
            {
                List<int> sides = new List<int>() { a, b, c };

                if (sides.Any(el => el <= 0) || a + b < c || a + c < b || c + b < a)
                {
                    MessageBox.Show("Введены неправильные данные!");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                }
                else
                {
                    double S = CheckSquare(a, b, c);
                    label4.Text = "Площадь\n" + Convert.ToString(S);
                    label5.Text = "Вид треугольника\n" + CheckTriangle(a, b, c) + $"\n{CheckAngle(a, b, c)}";
                }
                
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
