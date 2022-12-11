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
        Polinomial remainder;

        public Polinomial(Field _field, int size)
        {
            field = _field;
            for(int i = 0; i < size; i++)
            {
                polinomial.Add(field.getNullElement());
            }
            polinomialSize = size;
        }
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
                catch(Exception)
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
                catch (Exception)
                {
                    Console.WriteLine("polinomial fields not equal");
                }
            }
            return new Polinomial(resultElements, field);
        }

        public Polinomial divide(Polinomial p1, Polinomial p2)
        {
            ArrayList q = new ArrayList();
            ArrayList a = p1.copy();
            ArrayList b = p2.copy();

            int m = p1.getSize() - 1;
            int n = p2.getSize() - 1;
            q = initializeArray(m - n + 1);
            if (p1.getField().Equals(p2.getField()))
            {    
                for(int k = m-n; k >= 0; k--)
                {
                    q[k]  = field.divideElements((ArrayList)a[n + k], (ArrayList)b[n]);
                    //q[k] = field.divideElements((ArrayList)a[n + k], (ArrayList)b[n]);
                    for(int j = n + k; j >= k; j--)
                    {
                        a[j] = field.differenceElements((ArrayList)a[j], field.multiplyElements((ArrayList)q[k], (ArrayList)b[j - k]));
                    }
                }
            }
            else
            {
                try
                {
                    throw new Exception();
                }
                catch (Exception)
                {
                    Console.WriteLine("polinomial fields not equal");
                }
            }
            remainder = new Polinomial(a, field);
            return new Polinomial(q, field);
        }

        public Polinomial getRemainder() {
            return remainder;
        }

        ArrayList initializeArray(int res)
        {
            ArrayList result = new ArrayList();
            for(int i = 0; i < res; i++)
            {
                result.Add(field.getNullElement());
            }
            return result;
        }
        public Polinomial multiply(Polinomial p1, Polinomial p2)
        {      
            int m = p1.getSize() - 1;
            int n = p2.getSize() - 1;
            int resSize = m + n + 1;
            ArrayList arr = initializeArray(resSize);
            
            if (p1.getField().Equals(p2.getField()))
            {
                
                arr = initializeArray(resSize);
                for(int i = 0; i < p1.getSize(); i++)
                {
                    for(int j = 0; j < p2.getSize(); j++)
                    {
                        arr[i + j] = field.sumElements((ArrayList)arr[i + j], field.multiplyElements(p1.getElement(i), p2.getElement(j)));
                    }
                }
            }
            else
            {
                try
                {
                    throw new Exception();
                }
                catch (Exception )
                {
                    Console.WriteLine("polinomial fields not equal");
                }
            }
            return new Polinomial(arr, field);
        }

        public ArrayList copy()
        {
            ArrayList polinom = (ArrayList)polinomial.Clone();
            return polinom;
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

        public bool equals(Polinomial polinom)
        {
            if (this.getField().Equals(polinom.getField()))
            {
                int i = 0;
                for (i = 0; i < polinomial.Count && i < polinom.polinomial.Count; i++)
                {
                    if (field.getFieldElementPosition((ArrayList)this.polinomial[i]) != field.getFieldElementPosition((ArrayList)polinom.polinomial[i])) return false;
                }
                while(i < this.polinomial.Count)
                {
                    if (field.getFieldElementPosition((ArrayList)this.polinomial[i]) != 0) return false;
                    i++;
                }
                while(i < polinom.polinomial.Count)
                {
                    if (field.getFieldElementPosition((ArrayList)polinom.polinomial[i]) != 0) return false;
                    i++;
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
