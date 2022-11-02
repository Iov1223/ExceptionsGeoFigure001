using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsGeoFigure
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
                flag= false;
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
    class createFigure
    {
        private decimal numberOfFigures;
        private int count = 0;
        private GeoFigure[] myArray;
        private string answer, request;
        private bool isCorrect = false;
        CheckingParameters CP = new CheckingParameters();
        private void Request()
        {
            
            do
            {
                Console.Write("Сколько фигур хотите создать?:\nВвод -> ");
                request = Console.ReadLine();
                try
                {
                    CP.CheckParameters(request);
                    isCorrect = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
                numberOfFigures = CP.ReturnValue();
            } while (isCorrect == false);
        }
        private  void createAndWriteToArr()
        {
            Request();
            Console.WriteLine();
            myArray = new GeoFigure[(int)numberOfFigures];
            do
            {
                Console.WriteLine("Какую фигуру хотите создать?:\n" +
                    "1 - ПРЯМОУГОЛЬНИК\n" +
                    "2 - TРЕУГОЛЬНИК\n" +
                    "3 - КРУГ");
                Console.Write("Ввод -> ");
                answer = Console.ReadLine();
                
                try
                {
                    try
                    {
                        CP.CheckParameters(answer);
                        isCorrect = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка: {ex.Message}");
                    }
                    answer = Convert.ToString(CP.ReturnValue());
                    if (answer == "1")
                    {
                        Rectangle myRectangle = new Rectangle();
                        myArray[count] = myRectangle;
                        count++;
                    }
                    else if (answer == "2")
                    {
                        Triangle myTriangle = new Triangle();
                        myArray[count] = myTriangle;
                        count++;
                    }
                    else if (answer == "3")
                    {
                        Сircle myСircle = new Сircle();
                        myArray[count] = myСircle;
                        count++;
                    }
                    else
                    {
                        throw new Exception("Такого варианта нет!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
                Console.WriteLine("Для продолжения нажмите любую клавишу...");
                Console.ReadKey();
                Console.Clear();
            } while (count < numberOfFigures);
        }
        public void PrintResult()
        {
            createAndWriteToArr();
            for (int i = 0; i < myArray.Length; i++)
            {
                Console.WriteLine("{0}) {1}, площадь - {2} и периметр - {3} ",
                    i + 1, myArray[i].name, myArray[i].Square(), myArray[i].Perimeter());
            }
            Console.WriteLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            createFigure CF = new createFigure();
            CF.PrintResult();
        }
    }
}