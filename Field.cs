﻿using System;
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

        ArrayList nullElement = new ArrayList();
        ArrayList firstElement = new ArrayList();

        public Field(int _size, int _module, ArrayList _primitivePolinomial)
        {
            size = _size;
            module = _module;
            primitivePolinomial = _primitivePolinomial;

            int degreeIterator = 0;
            int buffer = 1;
            while (buffer != _size)
            {
                buffer *= _module;
                degreeIterator++;
            }

            moduleDegree = degreeIterator;

            for (int arrayIterator = 0; arrayIterator < moduleDegree; arrayIterator++)
            {
                nullElement.Add(0);
            }

            firstElement = (ArrayList)nullElement.Clone();
            firstElement[0] = 1;

            if (moduleDegree == 1)
            {
                elements = new ArrayList();
                for (int element = 0; element < module; element++)
                {
                    ArrayList current = new ArrayList();
                    current.Add(element);
                    elements.Add(current);
                }
            }

            else if (isPrimitivePolinomial(primitivePolinomial) == false)
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

        public ArrayList getElements() {
            return elements;
        }

        public ArrayList getNullElement()
        {
            return nullElement;
        }

        public ArrayList sumElements(ArrayList a, ArrayList b)
        {
            ArrayList result = new ArrayList();

            if (isFieldElement(a) && isFieldElement(b))
            {
                for (int iterator = 0; iterator < a.Count; iterator++)
                {
                    result.Add(((int)a[iterator] + (int)b[iterator]) % module);
                }

                return result;
            }
            else
            {
                try
                {
                    throw new Exception();
                }
                catch
                {
                    Console.WriteLine(a.ToString() + ", " + b.ToString() + " is not found with field\n");
                }
            }

            return result;
        }

        public ArrayList differenceElements(ArrayList a, ArrayList b)
        {
            ArrayList result = new ArrayList();

            if (isFieldElement(a) && isFieldElement(b))
            {
                for (int iterator = 0; iterator < a.Count; iterator++)
                {
                    int resultValue = 0;
                    if((int)a[iterator] >= (int)b[iterator]){
                        resultValue = (int)a[iterator] - (int)b[iterator];
                    }
                    else
                    {
                        resultValue = (int)a[iterator] - (int)b[iterator] + module;
                    }
                    result.Add(resultValue % module);
                }

                return result;
            }
            else
            {
                try
                {
                    throw new Exception();
                }
                catch
                {
                    Console.WriteLine(a.ToString() + ", " + b.ToString() + " is not found with field\n");
                }
            }

            return result;
        }

        public ArrayList multiplyElements(ArrayList first, ArrayList second)
        {
            ArrayList result = new ArrayList();

            if (isFieldElement(first) && isFieldElement(second))
            {
                if (moduleDegree == 1)
                {
                    result.Add(((int)first[0] * (int)second[0]) % module);
                    return result;
                }

                if ((first.ToArray() as IStructuralEquatable).Equals(nullElement.ToArray(), EqualityComparer<int>.Default) 
                    || (second.ToArray() as IStructuralEquatable).Equals(nullElement.ToArray(), EqualityComparer<int>.Default))
                {
                    result = (ArrayList)nullElement.Clone();
                    return result;
                }

                if ((first.ToArray() as IStructuralEquatable).Equals(firstElement.ToArray(), EqualityComparer<int>.Default))
                {
                    result = (ArrayList)second.Clone();
                    return result;
                }

                if ((second.ToArray() as IStructuralEquatable).Equals(firstElement.ToArray(), EqualityComparer<int>.Default))
                {
                    result = (ArrayList)first.Clone();
                    return result;
                }

                int firstDegree = getFieldElementPosition(first) - 1; // because field contains 0 and 1
                int secondDegree = getFieldElementPosition(second) - 1;

                if(firstDegree == -1 || secondDegree == -1) // 0 * a = 0, a * 0 = 0, 0 * 0 = 0
                {
                    return (ArrayList)elements[0]; // null element
                }

                if(firstDegree == 0) // 1 * a = a
                {
                    return second;
                }
                if(secondDegree == 0) // a * 1 = a
                {
                    return first;
                }

                int degreeEqualPrimitiveElement = size - 1;
                int resultDegree = (firstDegree + secondDegree) % degreeEqualPrimitiveElement;

                result = (ArrayList)elements[resultDegree + 1]; // because field contains 0 and 1
                return result;
            }
            else
            {
                try
                {
                    throw new Exception();
                }
                catch
                {
                    Console.WriteLine(first.ToString() + ", " + second.ToString() + " is not found with field\n");
                }
            }

            return result;
        }

        public ArrayList divideElements(ArrayList first, ArrayList second) // first \ second
        {
            return multiplyElements(first, this.inverseElement(second));
        }

        public ArrayList inverseElement(ArrayList element) {

            for(int iterator = 0; iterator < elements.Count; iterator++)
            {
                ArrayList current = (ArrayList) elements[iterator];

                if ((this.multiplyElements(current, element).ToArray() as IStructuralEquatable).Equals(firstElement.ToArray(), EqualityComparer<int>.Default))
                {
                    return current;
                }
            }
            
            return nullElement;
        }
        public string fieldToString()
        {
            string result = "0\n1\n";

            if (moduleDegree == 1)
            {
                for (int element = 2; element < module; element++)
                {
                    result += element.ToString();
                    result += "\n";
                }
            }
            else
            {

                for (int elementIterator = 2; elementIterator < elements.Count; elementIterator++)
                {
                    ArrayList element = (ArrayList)elements[elementIterator];
                    string elementS = "";

                    for (int iterator = 0; iterator < element.Count; iterator++)
                    {
                        elementS = elementToString(element);
                    }
                    result += elementS;
                    result += '\n';
                }
            }

            return result;
        }

        public static string elementToString(ArrayList element)
        {
            string result = "";
            ArrayList nullElement = new ArrayList();
            for (int arrayIterator = 0; arrayIterator < element.Count; arrayIterator++)
            {
                nullElement.Add(0);
            }

            if ((element.ToArray() as IStructuralEquatable).Equals(nullElement.ToArray(), EqualityComparer<int>.Default))
            {
                return "0";
            }

            for (int iterator = 0; iterator < element.Count; iterator++)
            {
                if ((int)element[iterator] == 0) continue;
                if (result.Length != 0) result += " + ";
                if ((int)element[iterator] != 1) result += element[iterator];
                if ((int)element[iterator] == 1 && iterator == 0) result += element[iterator];
                if (iterator == 0) continue;

                result += "a^(";
                result += iterator;
                result += ")";
            }

            return result;
        }

        public bool Equals(Field f2)
        {
            if ((elements.ToArray() as IStructuralEquatable).Equals(f2.elements.ToArray(), EqualityComparer<int>.Default))
            {
                return true;
            }
            return false;
        }

        private bool isFieldElement(ArrayList element) // converte to private later
        {
            return ((getFieldElementPosition(element) == -1) ? false : true);
        }
        public bool isPrimitivePolinomial(ArrayList polinomial)
        {
            bool nullPolinomial = true;
            for (int polinomIterator = 0; polinomIterator < polinomial.Count; polinomIterator++)
            {
                if ((int)polinomial[polinomIterator] != 0) nullPolinomial = false;
            }
            if (nullPolinomial == true) return false;

            if ((elements = createField(module, moduleDegree, size, polinomial)).Count == size) return true;
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

            ArrayList firstElement = new ArrayList();
            firstElement = (ArrayList)nullElement.Clone();
            firstElement[0] = 1;
            result.Add(firstElement);

            for (int count = result.Count; count < size; count++)
            {
                ArrayList currentElement = new ArrayList();
                currentElement = (ArrayList)((ArrayList)result[count - 1]).Clone();

                int buffer = 0;
                for (int currentIterator = currentElement.Count - 1; currentIterator > 0; currentIterator--)
                {
                    if (currentIterator == currentElement.Count - 1) buffer = (int)currentElement[currentIterator];
                    currentElement[currentIterator] = currentElement[currentIterator - 1];
                }
                currentElement[0] = 0;

                if (buffer != 0)
                {
                    for (int currentIterator = 0; currentIterator < currentElement.Count; currentIterator++)
                    {
                        currentElement[currentIterator] = ((int)currentElement[currentIterator]
                            + buffer * (int)subPolinomial[currentIterator]) % module;
                    }
                }

                result.Add(currentElement);

                if ((currentElement.ToArray() as IStructuralEquatable).Equals(firstElement.ToArray(), EqualityComparer<int>.Default)) break;
            }
            return result;
        }

        public int getFieldElementPosition(ArrayList element) // converte to private later
        {
            int found = -1;
            for (int elementIterator = 0; elementIterator < elements.Count; elementIterator++)
            {
                ArrayList current = (ArrayList)elements[elementIterator];

                if ((current.ToArray() as IStructuralEquatable).Equals(element.ToArray(), EqualityComparer<int>.Default))
                {
                    found = elementIterator;
                    break;
                }
            }
            return found;
        }
    }
}
