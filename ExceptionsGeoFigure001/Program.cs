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
        public bool CheckParameters(string Parameter)
        {
            try
            {
                value = decimal.Parse(Parameter);
                if (value > 0)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Значение не может быть отрицательным или ровняться нулю!");
                    return false;
                }
            }
            catch
            {
                Console.WriteLine("Ввод должен содержать толко числа!");
                return false;
            }
        }
        public decimal ReturnValue()
        {
            return value;
        }
        public bool CheckTriangle(decimal AB, decimal BC, decimal AC)
        {
            if (AB < BC + AC)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Сумма первой и второй сторон не может быть меньше основания или равно ему!");
                return false;
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
                if (CP.CheckParameters(value))
                {
                    flag = true;
                }
                Lengh = CP.ReturnValue();
            } while (!flag);
            flag = false;
            do
            {
                Console.Write("Введите высоту: ");
                string value = Console.ReadLine();
                if (CP.CheckParameters(value))
                {
                    flag = true;
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
                    if (CP.CheckParameters(value))
                    {
                        flag = true;
                    }
                    AB = CP.ReturnValue();
                } while (!flag);
                flag = false;
                do
                {
                    Console.Write("Введите первую строну треугольника от основания до вершины: ");
                    string value = Console.ReadLine();
                    if (CP.CheckParameters(value))
                    {
                        flag = true;
                    }
                    BC = CP.ReturnValue();
                } while (!flag);
                flag = false;
                do
                {
                    Console.Write("Введите вторую строну треугольника от основания до вершины: ");
                    string value = Console.ReadLine();
                    if (CP.CheckParameters(value))
                    {
                        flag = true;
                    }
                    AC = CP.ReturnValue();
                } while (!flag);
                flag = false;
                if (CP.CheckTriangle(AB, BC, AC))
                {
                    flag = true;
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
                Console.Write("Введите радиус круга: ");
                string value = Console.ReadLine();
                if (CP.CheckParameters(value))
                {
                    flag = true;
                }
                Radius = CP.ReturnValue();
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
        private int numberOfFigures, count = 0;
        private GeoFigure[] myArray;
        private string answer, request;
        private bool isCorrect;
        private int Request()
        {
            do
            {
                Console.Write("Сколько фигур хотите создать?:\nВвод -> ");
                request = Console.ReadLine();
                isCorrect = Int32.TryParse(request, out int res);
                if (isCorrect)
                {
                    numberOfFigures = Convert.ToInt32(request);
                }
                else
                {
                    Console.WriteLine("Неверный ввод. Попробуйте ещё раз: ");
                    isCorrect = false;
                }
            } while (isCorrect == false);
            return numberOfFigures;
        }
        private GeoFigure[] createAndWriteToArr()
        {
            numberOfFigures = Request();
            Console.WriteLine();
            myArray = new GeoFigure[numberOfFigures];
            do
            {
                Console.WriteLine("Какую фигуру хотите создать?:\n" +
                    "1 - ПРЯМОУГОЛЬНИК\n" +
                    "2 - TРЕУГОЛЬНИК\n" +
                    "3 - КРУГ");
                Console.Write("Ввод -> ");
                answer = Console.ReadLine();
                Console.WriteLine();
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
                    Console.WriteLine("Такого варианта нет, попробуйте ещё раз.\n");
                }
                Console.Clear();
            } while (count < numberOfFigures);
            return myArray;
        }
        public void PrintResult()
        {
            myArray = createAndWriteToArr();
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