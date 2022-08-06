namespace PowerLineCarTask.Cars
{
    public class Person 
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Person(string name, int age = 20)
        {
            Name = name;
            Age = age;
        }
    }

    public class PassengerCar : Car
    {
        private const double Slowdown = 0.06;

        public readonly Person[] Passengers;

        public readonly int MaxPassengerCount;

        public int PassengerCount { get; private set; }

        public PassengerCar(VehicleType type, double avgFuelConsumption, double maxFuelVolume, int maxPassengerCount) : base(type, avgFuelConsumption, maxFuelVolume)
        {
            if (maxPassengerCount < 0)
                throw new PassengerCarException("Max passenger count must not be negative.");

            Passengers = new Person[maxPassengerCount];
            MaxPassengerCount = maxPassengerCount;
            PassengerCount = 0;
        }

        public void AddPassenger(Person person) 
        {
            if (PassengerCount == MaxPassengerCount)
                throw new PassengerCarException("Too many passengers.");

            Passengers[PassengerCount] = person;
            PassengerCount++;
        }

        public void RemovePassenger()
        {
            if (PassengerCount == 0)
                throw new PassengerCarException("Car has not passengers");

            Passengers[PassengerCount-1] = null;
            PassengerCount--;
        }

        public override double GetMaxTravelDistance()
        {
            double distanse = base.GetMaxTravelDistance();

            return distanse * Math.Pow(1.0 - Slowdown, PassengerCount);
        }

        public override double GetTravelDistance()
        {
            double distanse = base.GetTravelDistance();

            return distanse * Math.Pow(1.0 - Slowdown, PassengerCount);
        }
    }

    public class PassengerCarException : CarException
    {
        public PassengerCarException(string message) : base(message)
        {
            //
        }
    }
}
