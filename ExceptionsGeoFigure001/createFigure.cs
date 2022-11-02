using System;

namespace ExceptionsGeoFigure001
{
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
        private void createAndWriteToArr()
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
}
