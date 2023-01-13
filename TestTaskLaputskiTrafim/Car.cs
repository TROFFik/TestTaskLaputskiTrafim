using System;

namespace TestTaskLaputskiTrafim
{
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
                switch (direction)
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
}
