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
            ArrayList primitivePolinomial = new ArrayList();
            /*
             * для поля 2^5 с многочленом x^5 + x^2 + 1/*
            primitivePolinomial.Add(1);
            primitivePolinomial.Add(0);
            primitivePolinomial.Add(1);
            primitivePolinomial.Add(0);
            primitivePolinomial.Add(0);
            primitivePolinomial.Add(1);

            Field f = new Field(32, 2, primitivePolinomial);/**/
            /*
            * для поля 3^3 с многочленом x^3 + 2x^2 + 1
            primitivePolinomial.Add(1);
            primitivePolinomial.Add(0);
            primitivePolinomial.Add(2);
            primitivePolinomial.Add(1);

            Field f = new Field(27, 3, primitivePolinomial);/**/
            /*
           * для поля 11 с многочленом 0

            Field f = new Field(11, 11, new ArrayList(0));/**/
            /*
             * для поля 2^5 с многочленом x^5 + x^4+ x^2 + 1/**/
            primitivePolinomial.Add(1);
            primitivePolinomial.Add(0);
            primitivePolinomial.Add(1);
            primitivePolinomial.Add(0);
            primitivePolinomial.Add(1);
            primitivePolinomial.Add(1);

            Field f = new Field(32, 2, primitivePolinomial);/**/
            Console.WriteLine(f.fieldToString());
            Console.Read();
        }
    }
}
