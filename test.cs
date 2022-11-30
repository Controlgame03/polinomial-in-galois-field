using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace PolinomialOperations
{
    class test
    {
        static void Main(String[] argv)
        {
            operationTest();
        }

        public static void operationTest() {
            ArrayList primitivePolinomial = new ArrayList();
            /*
            * для поля 3^3 с многочленом x^3 + 2x^2 + 1*/
            primitivePolinomial.Add(1);
            primitivePolinomial.Add(0);
            primitivePolinomial.Add(2);
            primitivePolinomial.Add(1);

            Field f = new Field(27, 3, primitivePolinomial);
            //Field f = new Field(11, 11, primitivePolinomial);

            string fieldToString = f.fieldToString();

            string result = f.ToString() + "\n\n\n" + "<------------------------->\n";
            string operation = " * ";

            ArrayList elements = f.getElements();

            Random rand = new Random();

            int testNumber = 100;
            int trues = 0;
            for (int i = 0; i < testNumber; i++)
            {
                ArrayList a = (ArrayList)elements[rand.Next(0, elements.Count - 1)];
                ArrayList b = (ArrayList)elements[rand.Next(0, elements.Count - 1)];

                ArrayList resultOperation = f.multiplyElements(a, b);
                result += "(" + f.elementToString(a) + ")" + operation + "(" + f.elementToString(b) + ")" + " == " + "(" + f.elementToString(resultOperation) + ")\n";
                if (f.isFieldElement(resultOperation))
                {
                    trues++;
                }
            }

            result += "true = " + trues;
            Console.Read();
        }
    }
}

/*
 30.11 (8:00 - 10:00):
    Сделал опреации сложения, вычитания и умножения. Не до конца отладил.
    На след. раз --->   <-> Полностью отладить сложение, вычитание и умножение;
                        <-> Особо учитывать момет поля GF(p^1);
                        <-> Написать метод деления елементов (переделать сложение);
                        <-> Написать метод для поиска обратного элемента (возможны трудности)
 
 */
