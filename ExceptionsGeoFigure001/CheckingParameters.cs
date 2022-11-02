using System;

namespace ExceptionsGeoFigure001
{
    class CheckingParameters
    {
        public decimal value;
        public void CheckParameters(string Parameter)
        {
            if (Decimal.TryParse(Parameter, out var res))
            {
                value = res;
                if (value <= 0)
                {
                    throw new Exception("Значение не может быть отрицательным или ровняться нулю!");
                }
            }
            else
            {
                throw new Exception("Ввод должен содержать толко числа!");
            }
        }
        public decimal ReturnValue()
        {
            return value;
        }
        public void CheckTriangle(decimal AB, decimal BC, decimal AC)
        {
            if (BC + AC <= AB)
            {
                throw new Exception("Сумма первой и второй сторон не может быть меньше основания или равно ему!");
            }
        }
    }
    
}
