namespace TestTaskLaputskiTrafim
{
    class SUV : Car
    {
        private int _wheelSize;
        public SUV(string brand, int maxSpeed, int maxHealth, int armorСoefficient, int wheelSize) : base(brand, maxSpeed, maxHealth, armorСoefficient)
        {
            _wheelSize = wheelSize;

            _armorСoefficient += _wheelSize; // меняем коэффециент в сооиветствии с новым параметром
        }
    }
}
