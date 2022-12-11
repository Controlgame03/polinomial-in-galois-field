using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace PolinomialOperations
{
    public partial class Form1 : Form
    {
        int prime = 2;
        int degree = 1;
        int fieldSize = 0;

        static int MAX_DEGREE = 6;
        static int MIN_DEGREE = 1;
        static int MAX_PRIME = 100;
        static int MIN_PRIME = 2;

        ArrayList boxes = new ArrayList();
        ArrayList labels = new ArrayList();

        ArrayList polinom1Boxes = new ArrayList();
        ArrayList polinom1Labels = new ArrayList();

        ArrayList polinom2Boxes = new ArrayList();
        ArrayList polinom2Labels = new ArrayList();

        Field field;

        ArrayList elements;

        int polinom1Size;
        int polinom2Size;

        ArrayList firstPolinomialArray = new ArrayList();
        ArrayList secondPolinomialArray = new ArrayList();

        public Form1()
        {
            InitializeComponent();
            polinom1Labels.Add(label100);
            polinom1Labels.Add(label101);
            polinom1Labels.Add(label102);
            polinom1Labels.Add(label103);
            polinom1Labels.Add(label104);
            polinom1Labels.Add(label105);
            polinom1Labels.Add(label106);
            polinom1Labels.Add(label107);
            polinom1Labels.Add(label108);
            polinom1Labels.Add(label109);
            polinom1Labels.Add(label110);

            polinom1Boxes.Add(comboBox100);
            polinom1Boxes.Add(comboBox101);
            polinom1Boxes.Add(comboBox102);
            polinom1Boxes.Add(comboBox103);
            polinom1Boxes.Add(comboBox104);
            polinom1Boxes.Add(comboBox105);
            polinom1Boxes.Add(comboBox106);
            polinom1Boxes.Add(comboBox107);
            polinom1Boxes.Add(comboBox108);
            polinom1Boxes.Add(comboBox109);
            polinom1Boxes.Add(comboBox110);

            polinom2Labels.Add(label200);
            polinom2Labels.Add(label201);
            polinom2Labels.Add(label202);
            polinom2Labels.Add(label203);
            polinom2Labels.Add(label204);
            polinom2Labels.Add(label205);
            polinom2Labels.Add(label206);
            polinom2Labels.Add(label207);
            polinom2Labels.Add(label208);
            polinom2Labels.Add(label209);
            polinom2Labels.Add(label210);

            polinom2Boxes.Add(comboBox200);
            polinom2Boxes.Add(comboBox201);
            polinom2Boxes.Add(comboBox202);
            polinom2Boxes.Add(comboBox203);
            polinom2Boxes.Add(comboBox204);
            polinom2Boxes.Add(comboBox205);
            polinom2Boxes.Add(comboBox206);
            polinom2Boxes.Add(comboBox207);
            polinom2Boxes.Add(comboBox208);
            polinom2Boxes.Add(comboBox209);
            polinom2Boxes.Add(comboBox210);
        }

        public static string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        private bool isPrimeNumber(int number)
        {

            if (number == 0 || number == 1)
            {
                return false;
            }
            else
            {
                for (int iterator = 2; iterator <= number / 2; iterator++)
                {
                    if (number % iterator == 0)
                    {
                        return false;
                    }

                }
                return true;
            }
        }

        private void initializeField() {
            
            boxes.Add(comboBox1);
            boxes.Add(comboBox2);
            boxes.Add(comboBox3);
            boxes.Add(comboBox4);
            boxes.Add(comboBox5);
            boxes.Add(comboBox6);
            boxes.Add(comboBox7);
            
            labels.Add(label3);
            labels.Add(label4);
            labels.Add(label5);
            labels.Add(label6);
            labels.Add(label7);
            labels.Add(label8);
            labels.Add(label9);
            button4.Visible = true;
            if (degree != 1)
            {
                label10.Visible = true;
                
                ((Label)labels[degree]).Text = "x^" + degree;
                for (int i = 0; i <= degree; i++)
                {
                    ((ComboBox)boxes[i]).Visible = true;
                    ((Label)labels[i]).Visible = true;
                }
            }
            else
            {
                label10.Visible = false;

                for (int i = 0; i <= MAX_DEGREE; i++)
                {
                    ((ComboBox)boxes[i]).Visible = false;
                    ((Label)labels[i]).Visible = false;
                }
            }

            for(int i = 0; i < boxes.Count; i++)
            {
                ((ComboBox)boxes[i]).Items.Clear();
                for (int element = 0; element < prime; element++)
                {
                    ((ComboBox)boxes[i]).Items.Add(element);
                }
            }

        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                prime = Convert.ToInt32(textBox1.Text);
                if(prime > MAX_PRIME || prime < MIN_PRIME)
                {
                    throw new Exception();
                }
                if (!isPrimeNumber(prime))
                {
                    throw new Exception();
                }
                degree = Convert.ToInt32(textBox2.Text);
                if(degree > MAX_DEGREE || degree < MIN_DEGREE)
                {
                    throw new Exception();
                }
                initializeField();
                fieldSize = intPow(prime, degree);
            }
            catch (Exception)
            {
                MessageBox.Show("Проверьте корректность введёных данных");
                return;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private int intPow(int number, int deg)
        {
            int result = 1;
            for(int i = 0; i < deg; i++)
            {
                result = result * number;
            }
            return result;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            ArrayList primitivePolinomial = new ArrayList();
            for(int i = 0; i <= degree; i++)
            {
                primitivePolinomial.Add(Convert.ToInt32(((ComboBox)boxes[i]).Text));
            }



            field = new Field(fieldSize, prime, primitivePolinomial);
            if (field.isPrimitivePolinomial(primitivePolinomial) || degree == 1)
            {
                button4.Visible = false;
                label23.Visible = true;
                label24.Visible = true;
                comboBox51.Visible = true;
                comboBox52.Visible = true;

            }

            else
            {
                //ввод заного
            }

            

        }

        void inputPolinomials()
        {
            label35.Visible = true;
            label36.Visible = true;
            ((Label)polinom1Labels[polinom1Size - 1]).Text = "x^" + (polinom1Size - 1);
            ((Label)polinom2Labels[polinom2Size - 1]).Text = "x^" + (polinom2Size - 1);
            for (int i = 0; i < polinom1Size; i++)
            {
                ((ComboBox)polinom1Boxes[i]).Visible = true;
                ((Label)polinom1Labels[i]).Visible = true;
            }

            for (int i = 0; i < polinom2Size; i++)
            {
                ((ComboBox)polinom2Boxes[i]).Visible = true;
                ((Label)polinom2Labels[i]).Visible = true;
            }

            elements = field.getElements();
            for(int i = 0; i < polinom1Size; i++)
            {
                for(int j = 0; j < elements.Count; j++)
                {
                    ((ComboBox)polinom1Boxes[i]).Items.Add(Field.elementToString((ArrayList)elements[j]));
                }
            }

            for (int i = 0; i < polinom2Size; i++)
            {
                for (int j = 0; j < elements.Count; j++)
                {
                    ((ComboBox)polinom2Boxes[i]).Items.Add(Field.elementToString((ArrayList)elements[j]));
                }
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox14_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                polinom1Size = Convert.ToInt32(comboBox51.Text);
                polinom2Size = Convert.ToInt32(comboBox52.Text);
                inputPolinomials();
            }
            catch (Exception)
            {
                MessageBox.Show("Проверьте корректность введёных данных");
                return;
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < polinom1Size; i++)
            {
                firstPolinomialArray.Add(elements[((ComboBox)polinom1Boxes[i]).SelectedIndex]);
            }

            for (int i = 0; i < polinom2Size; i++)
            {
                secondPolinomialArray.Add(elements[((ComboBox)polinom2Boxes[i]).SelectedIndex]);
            }

            Polinomial firstPolinomial = new Polinomial(firstPolinomialArray, field);
            Polinomial secondPolinomial = new Polinomial(secondPolinomialArray, field);

            Polinomial result;
            
            switch (comboBox8.SelectedItem.ToString())
            {
                case "+":
                    result = firstPolinomial.sum(firstPolinomial, secondPolinomial);
                    textBox3.Text = result.polinomialToString();
                    break;
                case "-":
                    result = firstPolinomial.difference(firstPolinomial, secondPolinomial);
                    textBox3.Text = result.polinomialToString();
                    break;
                case "*":
                    result = firstPolinomial.multiply(firstPolinomial, secondPolinomial);
                    textBox3.Text = result.polinomialToString();
                    break;
                case "|":
                    result = firstPolinomial.divide(firstPolinomial, secondPolinomial);
                    textBox3.Text = result.polinomialToString();
                    break;
            }

            
        }
    }
}
