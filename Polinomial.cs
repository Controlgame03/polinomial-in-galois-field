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

        public String polinomialToString() {
            String result = "";

            for(int iterator = 0; iterator < polinomialSize; iterator++)
            {
                result += Field.elementToString((ArrayList)polinomial[iterator]);
                result += " x^(";
                result += iterator;
                result += ") + ";
            }

            return result;
        }
    }
}
