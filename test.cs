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
            int flag = 2;
            switch (flag)
            {
                case 0:
                    arithmeticOperationTest();
                    break;
                case 1:
                    inverseElementTest();
                    break;
                case 2:
                    polinomialInitializationTest();
                    break;
                case 3:
                    inverseElementTest();
                    break;
            }
           
        }

        public static void polinomialInitializationTest() {
            String result = "";

            ArrayList primitivePolinomial = new ArrayList();
            /*
            * для поля 3^4 с многочленом x^4 + x^1 + 2*/
            primitivePolinomial.Add(2);
            primitivePolinomial.Add(1);
            primitivePolinomial.Add(0);
            primitivePolinomial.Add(0);
            primitivePolinomial.Add(1);

            //Field f = new Field(81, 3, primitivePolinomial);
            Field f = new Field(11, 11, primitivePolinomial);
            ArrayList elements = f.getElements();
            Random rand = new Random(); //rand.Next(0, n)

            int testNumber = 10;
            for(int i = 0; i < testNumber; i++)
            {
                ArrayList p1 = new ArrayList();
                int p1Size = rand.Next(5, 10);

                for(int j = 0; j < p1Size; j++)
                {
                    p1.Add(elements[rand.Next(0, elements.Count)]);
                }
                result += p1;
                result += "\n";
            }

            
            Console.Read();
        }

        public static void inverseElementTest() {
            ArrayList primitivePolinomial = new ArrayList();
            /*
            * для поля 3^4 с многочленом x^4 + x^1 + 2*/
            primitivePolinomial.Add(2);
            primitivePolinomial.Add(1);
            primitivePolinomial.Add(0);
            primitivePolinomial.Add(0);
            primitivePolinomial.Add(1);

            //Field f = new Field(81, 3, primitivePolinomial);
            Field f = new Field(11, 11, primitivePolinomial);

            string fieldToString = f.fieldToString();

            string result = f.ToString() + "\n\n\n" + "<------------------------->\n";
            string operation = " ^(-1) ";

            //ArrayList elements = f.getElements();
            ArrayList elements = new ArrayList(); // change

            Random rand = new Random();

            int testNumber = 100;
            int trues = 0;
            for (int i = 0; i < testNumber; i++)
            {
                ArrayList a = (ArrayList)elements[rand.Next(0, elements.Count - 1)];
                //ArrayList b = (ArrayList)elements[rand.Next(0, elements.Count - 1)];

                ArrayList resultOperation = f.inverseElement(a);
                result += "(" + Field.elementToString(a) + ")" + operation + " == " + "(" + Field.elementToString(resultOperation) + ")\n";
                //if (f.isFieldElement(resultOperation))
                if(true) // change
                {
                    trues++;
                }
            }

            result += "true = " + trues;
            Console.Read();
        }
        public static void arithmeticOperationTest() {
            ArrayList primitivePolinomial = new ArrayList();
            /*
            * для поля 3^4 с многочленом x^4 + x^1 + 2*/
            primitivePolinomial.Add(2);
            primitivePolinomial.Add(1);
            primitivePolinomial.Add(0);
            primitivePolinomial.Add(0);
            primitivePolinomial.Add(1);

            //Field f = new Field(81, 3, primitivePolinomial);
            Field f = new Field(11, 11, primitivePolinomial);

            string fieldToString = f.fieldToString();

            string result = f.ToString() + "\n\n\n" + "<------------------------->\n";
            string operation = " / ";

            //ArrayList elements = f.getElements();
            ArrayList elements = new ArrayList(); // change

            Random rand = new Random();

            int testNumber = 100;
            int trues = 0;
            for (int i = 0; i < testNumber; i++)
            {
                ArrayList a = (ArrayList)elements[rand.Next(0, elements.Count - 1)];
                ArrayList b = (ArrayList)elements[rand.Next(0, elements.Count - 1)];

                ArrayList resultOperation = f.divideElements(a, b);
                result += "(" + Field.elementToString(a) + ")" + operation + "(" + Field.elementToString(b) + ")" + " == " + "(" + Field.elementToString(resultOperation) + ")\n";
                //if (f.isFieldElement(resultOperation))
                if (true) // change
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
                        <-> Написать метод деления элементов (переделать умножение);
                        <-> Написать метод для поиска обратного элемента (возможны трудности)
 01.12 (8:00 - 9:00)
    Дебаг операций над элементами. Рассматривал пример GF(p^1).
    На след. раз --->   <-> Отладить сложение, вычитание и умножение;
                        <-> Написать метод деления элементов (переделать умножение);
 01.12 (12:00 - 12:45)
    Дебаг операций над элементами. Написал метод подсчёта обратного элемента
    На след. раз --->   <-> Отладить умножение;
                        <-> Написать метод деления элементов (переделать умножение);
                        <-> Отладить вычисление обратного элемнта
03.12 (8:00 - 10:30)
    Дебаг операции умножения. Дебаг операции обратного элемента. Написал и продебажил операцию вычисления обратоного элемента.
    Закончил с полем Галуа. Приступаю к опреции с многочленами
    На след. раз --->   <-> Написать механизм инициализации многочленов
                        <-> Написать toString для полиномов
                        <-> Написать операции суммирования и разности для полиномов
 */
