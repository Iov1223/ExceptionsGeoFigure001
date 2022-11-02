using System;

namespace ExceptionsGeoFigure001
{
    abstract class GeoFigure
    {
        private string Name;

        public string name
        {
            get { return Name; }
            set { Name = value; }
        }
        public abstract decimal Square();
        public abstract decimal Perimeter();
    }
    class Rectangle : GeoFigure
    {
        public Rectangle()
        {
            CheckingParameters CP = new CheckingParameters();
            bool flag = false;
            name = "ПРЯМОУГОЛЬНИК";
            do
            {
                Console.Write("Введите длину: ");
                string value = Console.ReadLine();
                try
                {
                    CP.CheckParameters(value);
                    flag = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
                Lengh = CP.ReturnValue();
            } while (!flag);
            flag = false;
            do
            {
                Console.Write("Введите высоту: ");
                string value = Console.ReadLine();
                try
                {
                    CP.CheckParameters(value);
                    flag = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
                Heigth = CP.ReturnValue();
            } while (!flag);
        }
        public override decimal Square()
        {
            decimal _square = this.lengh * this.heigth;
            return _square;
        }
        public override decimal Perimeter()
        {
            decimal _perimeter = this.lengh + this.lengh + this.heigth + this.heigth;
            return _perimeter;
        }
        private decimal Lengh;

        public decimal lengh
        {
            get { return Lengh; }
            set { Lengh = value; }
        }
        private decimal Heigth;

        public decimal heigth
        {
            get { return Heigth; }
            set { Heigth = value; }
        }
    }
    class Triangle : GeoFigure
    {

        public Triangle()
        {
            CheckingParameters CP = new CheckingParameters();
            bool flag = false;
            name = "TРЕУГОЛЬНИК";
            do
            {
                do
                {
                    Console.Write("Введите основание треугольника: ");
                    string value = Console.ReadLine();
                    try
                    {
                        CP.CheckParameters(value);
                        flag = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка: {ex.Message}");
                    }
                    AB = CP.ReturnValue();
                } while (!flag);
                flag = false;
                do
                {
                    Console.Write("Введите первую строну треугольника от основания до вершины: ");
                    string value = Console.ReadLine();
                    try
                    {
                        CP.CheckParameters(value);
                        flag = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка: {ex.Message}");
                    }
                    BC = CP.ReturnValue();
                } while (!flag);
                flag = false;
                do
                {
                    Console.Write("Введите вторую строну треугольника от основания до вершины: ");
                    string value = Console.ReadLine();
                    try
                    {
                        CP.CheckParameters(value);
                        flag = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка: {ex.Message}");
                    }
                    AC = CP.ReturnValue();
                } while (!flag);
                flag = false;
                try
                {
                    CP.CheckTriangle(AB, BC, AC);
                    flag = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            } while (!flag);
            Console.WriteLine();
        }
        private decimal AB;

        public decimal ab
        {
            get { return AB; }
            set { AB = value; }
        }
        private decimal BC;

        public decimal bc
        {
            get { return BC; }
            set { BC = value; }
        }
        private decimal AC;

        public decimal ac
        {
            get { return AC; }
            set { AC = value; }
        }
        public override decimal Perimeter()
        {
            decimal _perimeter = this.AB + this.AC + this.BC;
            return _perimeter;
        }
        public override decimal Square()
        {
            decimal P = (this.AB + this.AC + this.BC) / 2;
            return (decimal)Math.Sqrt((double)(P * (P - this.AB) * (P - this.BC) * (P - this.AC)));
        }
    }
    class Сircle : GeoFigure
    {
        public Сircle()
        {
            CheckingParameters CP = new CheckingParameters();
            bool flag = false;
            name = "КРУГ";
            do
            {
                do
                {
                    Console.Write("Введите радиус круга: ");
                    string value = Console.ReadLine();
                    try
                    {
                        CP.CheckParameters(value);
                        flag = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка: {ex.Message}");
                    }
                    Radius = CP.ReturnValue();
                } while (!flag);
            } while (!flag);
            PI = 3.14m;
        }
        private decimal Radius;
        public decimal radius
        {
            get { return Radius; }
            set { Radius = value; }
        }
        private decimal PI;

        public decimal pi
        {
            get { return PI; }
            set { PI = value; }
        }

        public override decimal Perimeter()
        {
            decimal _perimeter = 2 * this.Radius * this.PI;
            return _perimeter;
        }
        public override decimal Square()
        {
            decimal _squere = this.PI * (this.Radius * this.Radius);
            return _squere;
        }
    }
}
