using System;

namespace TestTaskLaputskiTrafim
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarShop _carShop = new CarShop();
            ServiceStation _station = new ServiceStation();
            Car _car = null;

            ConsoleKeyInfo _key;

            do
            {
                Console.Clear();

                Console.WriteLine("Нажмите Q чтобы купить новый автомобиль");
                Console.WriteLine("Нажмите W чтобы осмотреть автомобиль");
                Console.WriteLine("Нажмите E чтобы починить автомобиль");
                Console.WriteLine("Нажмите R чтобы прокатиться на автомобиле");
                Console.WriteLine("Нажмите Escape чтобы покинуть это место");

                _key = Console.ReadKey();

                if (_key.Key != ConsoleKey.Q && _car == null )
                {
                    Console.WriteLine("Cначала купите машину!");
                    Console.ReadKey();
                }
                else
                {
                    switch (_key.Key)
                    {
                        case ConsoleKey.Q:
                            _car = BuyNewCar(_carShop);
                            break;

                        case ConsoleKey.W:

                            Console.WriteLine("Здоровье автомобиля: " + _car.Health);
                            Console.ReadKey();
                            break;

                        case ConsoleKey.E:

                            _station.FixCar(_car);
                            Console.WriteLine("Здоровье автомобиля: " + _car.Health);
                            Console.ReadKey();
                            break;

                        case ConsoleKey.R:

                            Driving(_car);
                            Console.ReadKey();
                            break;

                        default:
                            break;
                    }
                }                
            }
            while (_key.Key != ConsoleKey.Escape); // по нажатию на Escape завершаем цикл 
        }

        private static Car BuyNewCar(CarShop carShop)
        {
            Console.Clear();
            Console.WriteLine("Введите марку желаемого автомобиля");

            string carBrend = Console.ReadLine();

            Console.WriteLine("Нажмите Q чтобы купить легковушку");
            Console.WriteLine("Нажмите W чтобы купить внедорожник");
            Console.WriteLine("Нажмите E чтобы купить грузовик");

            ConsoleKeyInfo key;
            key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.Q:
                    return carShop.GetCar(0, carBrend);

                case ConsoleKey.W:
                    return carShop.GetCar(1, carBrend);

                case ConsoleKey.E:
                    return carShop.GetCar(2, carBrend);

                default:
                    Console.WriteLine("Такого варианта нету");
                    return null;
            }
        }

        private static void Driving(Car car)
        {
            Console.WriteLine("Нажмите W чтобы ехать прямо");
            Console.WriteLine("Нажмите A чтобы ехать налево");
            Console.WriteLine("Нажмите D чтобы ехать направо");
            Console.WriteLine("Нажмите S чтобы ехать назад");

            ConsoleKeyInfo key;
            key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.W:
                    car.Drive(0);
                    break;

                case ConsoleKey.A:
                    car.Drive(1);
                    break;

                case ConsoleKey.S:
                    car.Drive(2);
                    break;

                case ConsoleKey.D:
                    car.Drive(3);
                    break;
                default:
                    Console.WriteLine("Такого варианта нету");
                    break;
            }
        }
    }
}
