using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace PolinomialOperations
{
    class Polinomial
    {
        Field field;
        ArrayList polinomial;

        int polinomialSize;

        public Polinomial(ArrayList _polinomial, Field _field)
        {
            field = _field;
            polinomial = _polinomial;
            polinomialSize = polinomial.Count;
        }
        public int getSize()
        {
            return polinomialSize;
        }
        public Field getField() {
            return field;
        }

        public ArrayList getElement(int position)
        {
            if (position >= polinomialSize)
            {
                return field.getNullElement();
            }
            return (ArrayList)polinomial[position];
        }

        public Polinomial sum(Polinomial p1, Polinomial p2)
        {
            ArrayList resultElements = new ArrayList();
            if (p1.getField().Equals(p2.getField()))
            {
                int size = (p1.getSize() > p2.getSize()) ? p1.getSize() : p2.getSize();

                for(int i = 0; i < size; i++)
                {
                    resultElements.Add(field.sumElements(p1.getElement(i), p2.getElement(i)));
                }
            }
            else
            {
                try
                {
                    throw new Exception();
                }
                catch(Exception e)
                {
                    Console.WriteLine("polinomial fields not equal");
                }
            }
            return new Polinomial(resultElements, field);
        }

        public ArrayList valueOf(ArrayList value)
        {
            ArrayList result = new ArrayList();
            ArrayList prev = new ArrayList();
            for(int iterator = polinomialSize - 1; iterator >= 0; iterator--)
            {
                if(iterator == polinomialSize - 1)
                {   
                    prev = (ArrayList)polinomial[polinomialSize - 1];
                    result = prev;
                    continue;
                }
                result = field.sumElements((ArrayList)polinomial[iterator], field.multiplyElements(value, prev));
                prev = result;
            }
            return result;
        }
        public Polinomial difference(Polinomial p1, Polinomial p2)
        {
            ArrayList resultElements = new ArrayList();
            if (p1.getField().Equals(p2.getField()))
            {
                int size = (p1.getSize() > p2.getSize()) ? p1.getSize() : p2.getSize();

                for (int i = 0; i < size; i++)
                {
                    resultElements.Add(field.differenceElements(p1.getElement(i), p2.getElement(i)));
                }
            }
            else
            {
                try
                {
                    throw new Exception();
                }
                catch (Exception e)
                {
                    Console.WriteLine("polinomial fields not equal");
                }
            }
            return new Polinomial(resultElements, field);
        }

        public String polinomialToString() {
            String result = "";

            for(int iterator = 0; iterator < polinomialSize; iterator++)
            {
                result += "(";
                result += Field.elementToString((ArrayList)polinomial[iterator]);
                result += ")";
                result += "*x^(";
                result += iterator;
                if (iterator + 1 != polinomialSize)
                {
                    result += ") + ";
                }
                else
                {
                    result += ")";
                }
            }

            return result;
        }
    }
}
