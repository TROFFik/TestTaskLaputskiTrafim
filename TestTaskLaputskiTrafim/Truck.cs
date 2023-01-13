namespace TestTaskLaputskiTrafim
{
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
