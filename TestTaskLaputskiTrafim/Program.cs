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

                switch (_key.Key)
                {
                    case ConsoleKey.Q:
                        _car = BuyNewCar(_car, _carShop);
                            break;

                    case ConsoleKey.W:

                        if (_car == null)
                        {
                            Console.WriteLine("Cначала купить машину!");
                        }
                        else
                        {
                            Console.WriteLine("Здоровье автомобиля: " + _car.Health);
                        }
                        Console.ReadKey();
                        break;

                    case ConsoleKey.E:

                        if (_car == null)
                        {
                            Console.WriteLine("Cначала купить машину!");
                        }
                        else
                        {
                            _station.FixCar(_car);
                            Console.WriteLine("Здоровье автомобиля: " + _car.Health);
                        }
                        Console.ReadKey();
                        break;

                    case ConsoleKey.R:
                        if(_car == null)
                        {
                            Console.WriteLine("Cначала купить машину!");
                        }
                        else
                        {
                            Driving(_car);
                        }
                        Console.ReadKey();
                        break;

                    default:
                        break;
                }
            }
            while (_key.Key != ConsoleKey.Escape); // по нажатию на Escape завершаем цикл 
        }

        private static Car BuyNewCar(Car car, CarShop carShop) // на юнити можно было бы изменять _car напрямую
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

    class CarShop
    {
        public Car GetCar(int carTypeID, string carBrend)
        {
            switch (carTypeID)
            {
                case 0:
                    return new PassengerCar(carBrend, 5, 10, 1, 6);

                case 1:
                    return new SUV(carBrend, 10, 20, 3, 2);

                case 2:
                    return new Truck(carBrend, 3, 30, 2, 5);

                default:
                    Console.WriteLine("Такого варианта нету");
                    Console.ReadKey();
                    return null;
            }
        }
    }

    class ServiceStation
    {
        public void FixCar(Car car)
        {
            car.Health = 10;
        }
    }

    public abstract class Car // создаем базовый класс машины с одинаковыми параметрами и методами для всех наследуемых машин 
    {
        protected Guid _licensePlate; // базовые параметры автомобиля
        protected string _brand;
        protected int _maxSpeed;
        protected int _maxHealth;
        protected int _armorСoefficient;
        protected int _health;

        public int Health // делаем читаемым и изменяемым (для ремонта) текущее состояние автомобиля 
        {
            get { return _health; }

            set
            {
                _health += value; // чиним авто

                _health = _health > _maxHealth ? _maxHealth : _health; //проверка выхода за пределы
            }
        }

        public Car(string brand, int maxSpeed, int maxHealth, int armorСoefficient) // конструктор класса 
        {
            _licensePlate = Guid.NewGuid(); // создаем уникальный номер машины
            _maxSpeed = maxSpeed;
            _maxHealth = maxHealth;
            _health = _maxHealth;
            _armorСoefficient = armorСoefficient;
            _brand = brand;

            if (_brand == "Лада") // добавляем щепотку реализма
            {
                _maxHealth = 1;
                _health = 0;
                _armorСoefficient = 0;
            }
        }

        public void Drive(int direction) // метод езды на автомобиле. direction по аналогии движения в юнити: т.е. вектор направоения движения 
        {
            if (_health > 0) // делаем проверку на состояние автомобиля (если убитый - не едет)
            {
                switch(direction)
                {
                    case 0:
                        Console.WriteLine("Вы решили поехать прямо");
                        break;
                    case 1:
                        Console.WriteLine("Вы решили поехать налево");
                        break;
                    case 2:
                        Console.WriteLine("Вы решили поехать назад");
                        break;
                    case 3:
                        Console.WriteLine("Вы решили сдать направо");
                        break;
                }
                Console.WriteLine("Врум - Врум. Кчау");
                Damage(); // наносим урон при движении
            }
            else
            {
                Console.WriteLine("Машина сломана");
            }
        }

        private void Damage()
        {
            Random random = new Random(); // делаем экземпляр рандомайзера 

            int damage = random.Next(_maxHealth) - _armorСoefficient; // расчитываем дамаг машины

            damage = damage < 0 ? 0 : damage; // проверяем на то, чтобы дамаг не был отрицательным

            _health -= damage;

            _health = _health < 0 ? 0 : _health; // проверяем на то, чтобы здоровье не был отрицательным
        }
    }

    class PassengerCar : Car
    {
        private int _seatsCount; //дополнительный параметр автомобиля в зависимости от типа авто
        public PassengerCar(string brand, int maxSpeed, int maxHealth, int armorСoefficient, int seatsCount) : base(brand, maxSpeed, maxHealth, armorСoefficient)
        {
            _seatsCount = seatsCount;  
        }
    }

    class SUV : Car
    {
        private int _wheelSize;
        public SUV(string brand, int maxSpeed, int maxHealth, int armorСoefficient, int wheelSize) : base(brand, maxSpeed, maxHealth, armorСoefficient)
        {
            _wheelSize = wheelSize;

            _armorСoefficient += _wheelSize; // меняем коэффециент в сооиветствии с новым параметром
        }
    }

    class Truck : Car
    {
        private int _carryingCapacity;
        public Truck(string brand, int maxSpeed, int maxHealth, int armorСoefficient, int carryingCapacity) : base(brand, maxSpeed, maxHealth, armorСoefficient)
        {
            _carryingCapacity = carryingCapacity;

            _armorСoefficient -= carryingCapacity; // меняем коэффециент в сооиветствии с новым параметром

            _armorСoefficient = _carryingCapacity >= _armorСoefficient ? 1 : _armorСoefficient - _carryingCapacity; // проверка на адекватность значений
        }
    }
}
