using System;

namespace Game
{
    public class Calculator
    {
        public int Add(int a, int b) => a + b;

        public int Divide(int a, int b)
        {
            if (b == 0)
                throw new DivideByZeroException("No se puede dividir entre cero.");

            return a / b;
        }

        public bool IsEven(int value) => value % 2 == 0;
    }
}
