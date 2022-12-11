using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolinomialOperations
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        internal Polinomial Field
        {
            get => default;
            set
            {
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte q1;
            byte q2;
            try
            {
                q1 = Convert.ToByte(textBox1.Text);
                q2 = Convert.ToByte(textBox2.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Проверьте корректность введёных данных");
                return;
            }
           

            if (textBox3.Text == "")
            {
                MessageBox.Show("Ответ: 0");
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public static string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        public static string CreatePolynom(byte s)
        {
            string str1, res1 = "";
            int i = 0;
            str1 = Convert.ToString(s, 2);
            str1 = ReverseString(str1);
            foreach (char ch in str1)
            {
                if (ch == '1')
                {
                    if (i == 0)
                    {
                        res1 = res1 + "1 +";
                    }
                    else
                    {
                        res1 = res1 + "x^" + Convert.ToString(i) + "+";
                    }
                }
                i++;
            };
            try
            {
                res1 = res1.Remove(res1.Length - 1);
            } catch (Exception)
            {
                res1 = "";
            }
            
            return res1;
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            byte q1 = 0, q2 = 0;
            try
            {
                q1 = Convert.ToByte(textBox1.Text);
                q2 = Convert.ToByte(textBox2.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Проверьте корректность введёных данных");
                return;
            }
            tb_polynom1.Text = CreatePolynom(q1);
            tb_polynom2.Text = CreatePolynom(q2);
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Автор: Сергеев Денис Владиславович\nНазвание программы: Операции над многочленами в полях Галуа");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "^")
            {
                label9.Visible = true;
                textBox4.Visible = true;
            }
            else
            {
                label9.Visible = false;
                textBox4.Visible = false;
            }
        }

        private void загрузитьДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text files(*.text)|*.txt|All files(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;
            System.IO.StreamReader sr;
            try
            {
                sr = new System.IO.StreamReader(filename);
            } catch
            {
                MessageBox.Show("Файл не удалось открыть");
                return;
            }

            string str;
            string[] text;


            str = sr.ReadLine();
            text = str.Split(";");

            if (text.Length == 2)
            {
                try
                {
                    textBox1.Text = text[0];
                    textBox2.Text = text[1];
                } catch
                {
                    MessageBox.Show("Не удалось загрузить данные");
                }
            }

            sr.Close();
        }

        private void выгрузитьДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text files(*.text)|*.txt|All files(*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;
           
            System.IO.StreamWriter sw;
            try
            {
                sw = new System.IO.StreamWriter(filename);
            }
            catch
            {
                MessageBox.Show("Файл не удалось открыть");
                return;
            }

            try
            {
                sw.WriteLine("Входные данные: " + textBox1.Text + "     " + textBox2.Text);
                sw.WriteLine("Получившиеся полиномы: " + tb_polynom1.Text + "   " + tb_polynom2.Text);
                sw.WriteLine("Операция: " + comboBox1.Text);
                sw.WriteLine("Итоговый результата: " + textBox3.Text);
            } catch
            {
                MessageBox.Show("Не удалось записать данные в файл");
                sw.Close();
                return;
            }
            

            sw.Close();
            
            MessageBox.Show("Файл сохранен");
        }

        private void tb_polynom1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
