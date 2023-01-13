namespace TestTaskLaputskiTrafim
{
    class PassengerCar : Car
    {
        private int _seatsCount; //дополнительный параметр автомобиля в зависимости от типа авто
        public PassengerCar(string brand, int maxSpeed, int maxHealth, int armorСoefficient, int seatsCount) : base(brand, maxSpeed, maxHealth, armorСoefficient)
        {
            _seatsCount = seatsCount;
        }
    }
}
