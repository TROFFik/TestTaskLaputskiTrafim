using System;

namespace TestTaskLaputskiTrafim
{
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
}
