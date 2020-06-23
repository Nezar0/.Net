using System;

namespace patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Car Sportscar = new Car(new SportscarFactory());
            Sportscar.Speed();
            Sportscar.SpeedUp();

            Car SUV = new Car(new SUVFactory());
            SUV.Speed();
            SUV.SpeedUp();

            Console.ReadLine();
        }
    }
    abstract class MSpeed
    {
        public abstract void Speed();
    }

    abstract class Boost
    {
        public abstract void SpeedUp();
    }

    class SpeedNow : MSpeed
    {    
        public override void Speed()
        {
            Random rnd = new Random();
            int value = rnd.Next(100, 300);
            Console.WriteLine("двигаемся со скоростью "+ value + " km/h");
        }   
    }
    class SpeedReduction : Boost
    {
        public override void SpeedUp()
        {
            Console.WriteLine("Понижаем скорость");
        }
    }
    class SpeedIncrease : Boost
    {
        public override void SpeedUp()
        {
            Console.WriteLine("Повышаем скорость");
        }
    }
    abstract class CarFactory
    {
        public abstract Boost CreateBoost();
        public abstract MSpeed CreateSpeed();
    }

    class SportscarFactory : CarFactory
    {
        public override Boost CreateBoost()
        {
            return new SpeedReduction();
        }

        public override MSpeed CreateSpeed()
        {
            return new SpeedNow();
        }
    }
    class SUVFactory : CarFactory
    {
        public override Boost CreateBoost()
        {
            return new SpeedIncrease();
        }

        public override MSpeed CreateSpeed()
        {
            return new SpeedNow();
        }
    }
    class Car
    {
        private MSpeed maxspeed;
        private Boost boost;
        public Car(CarFactory factory)
        {
            maxspeed = factory.CreateSpeed();
            boost = factory.CreateBoost();
        }
        public void SpeedUp()
        {
            boost.SpeedUp();
        }
        public void Speed()
        {
            maxspeed.Speed();
        }
    }
}
