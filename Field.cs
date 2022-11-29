using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace PolinomialOperations
{
    class Field
    {
        // класс который принимает на вход модуль n
        // и дает возможность вычитать, умножать, складывать и делить элементы над полем.

        int size;
        int module;
        int moduleDegree;

        ArrayList primitivePolinomial;

        ArrayList elements; 

        public Field(int _size, int _module)
        {
            size = _size;
            module = _module;

            int degreeIterator = 0;
            int buffer = 1;
            while(buffer != _size)
            {
                buffer *= _module;
                degreeIterator++;
            }

            moduleDegree = degreeIterator;

            primitivePolinomial = new ArrayList();

            for (int polinomialIterator = 0; polinomialIterator < moduleDegree; polinomialIterator++) primitivePolinomial.Add(0);

            bool flag = false;
            for (int polinomialIterator = 0; polinomialIterator < moduleDegree; polinomialIterator++)
            {
                for(int element = 0; element < module; element++)
                {
                    primitivePolinomial[polinomialIterator] = element;
                    if (flag = isPrimitivePolinomial(primitivePolinomial))
                    {
                        break;
                    }

                }
                if (flag)
                {
                    break;
                }
            }

            if(flag == true)
            {
                elements = createField(module, moduleDegree, size, primitivePolinomial);
            }
            else
            {
                try
                {
                    throw new Exception();
                }
                catch (Exception)
                {
                    Console.WriteLine("primitive polinomial for this galous field not founded");
                }
            }

            
        }
        private bool isPrimitivePolinomial(ArrayList polinomial) {
            bool nullPolinomial = true;
            for(int polinomIterator = 0; polinomIterator < polinomial.Count; polinomIterator++)
            {
                if ((int)polinomial[polinomIterator] != 0) nullPolinomial = false;
            }
            if (nullPolinomial == true) return false;

            if (createField(module, moduleDegree, size, polinomial).Count == size) return true;
            return false;
        }

        private static ArrayList createField(int module, int degree, int size, ArrayList polinomial)
        {
            ArrayList result = new ArrayList();

            // polinomial ---> x^n + a(n-1)*x^(n-1) + a(n-2)*x^(n-2) + ... + a(1)*x + a(0)
            // polinomialDegree ---> (n)
            int polinomialDegree = polinomial.Count - 1;
            // subPolinomial ---> (-a(n-1))*x^(n-1) + (-a(n-2))*x^(n-2) + ... + (-a(1))*x + (-a(0))
            ArrayList subPolinomial = new ArrayList();

            for (int arrayIterator = 0; arrayIterator < polinomialDegree; arrayIterator++)
            {
                subPolinomial.Add(((-1) * (int)polinomial[arrayIterator] + module) % module);
            }

            ArrayList nullElement = new ArrayList();
            for (int arrayIterator = 0; arrayIterator < polinomialDegree; arrayIterator++)
            {
                nullElement.Add(0);
            }
            result.Add(nullElement);


            for (int count = 1; count < size; count++)
            {
                ArrayList currentElement = new ArrayList();
                currentElement = (ArrayList)((ArrayList)result[count - 1]).Clone();

                int buffer = 0;
                for (int currentIterator = 1; currentIterator < currentElement.Count; currentIterator++)
                {
                    buffer = (int)currentElement[currentIterator];
                    currentElement[currentIterator] = currentElement[currentIterator - 1];
                }

                if (buffer != 0)
                {
                    for (int currentIterator = 0; currentIterator < currentElement.Count; currentIterator++)
                    {
                        currentElement[currentIterator] = ((int)currentElement[currentIterator]
                            + buffer * (int)subPolinomial[currentIterator] % module);
                    }
                }

                result.Add(currentElement);
            }
            return result;
        }

        public string fieldToString() {
            string result = "";

            for(int elementIterator = 0; elementIterator < elements.Count; elementIterator++)
            {
                ArrayList element = (ArrayList)elements[elementIterator];
                string elementToString = "";

                for(int iterator = 0; iterator < element.Count; iterator++)
                {
                    if (iterator != 0) elementToString += " + ";
                    elementToString += "a^(";
                    elementToString += element[iterator];
                    elementToString += ")";
                }
                result += elementToString;
                result += '\n';
            }

            return result;
        }

        public ArrayList sumElements(ArrayList a, ArrayList b)
        {
            return new ArrayList();
        }
        //и т.д. дореализовать операции над полем
    }
}
