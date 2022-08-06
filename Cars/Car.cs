namespace PowerLineCarTask.Cars
{
    public enum VehicleType 
    { 
        PassengerCar = 301,
        SpecialPassengerCar = 302,
        Truck = 303,
        SpecialTruck = 304
    }

    public abstract class Car
    {
        public readonly VehicleType Type;

        public readonly double AvgFuelConsumption; // liters by 100km

        public readonly double MaxFuelVolume; // liters

        private double _fuelVolume; 
        public double FuelVolume // liters
        { 
            get 
            { 
                return _fuelVolume; 
            } 
            set 
            { 
                if(value > MaxFuelVolume)
                    _fuelVolume = MaxFuelVolume;
                else
                    _fuelVolume = value;
            } 
        }

        private double _speed;
        public double Speed // km/hour
        {
            get
            {
                return _speed;
            }
            set
            {
                if (value < 0)
                    throw new CarException("Speed must not be negative.");
                _speed = value;
            }
        } 

        protected Car(VehicleType type, double avgFuelConsumption, double maxFuelVolume) 
        {
            if (avgFuelConsumption < 0)
                throw new CarException("Average fuel consumption must not be negative.");

            if (maxFuelVolume < 0)
                throw new CarException("Max fuel volume must not be negative.");

            Type = type;
            AvgFuelConsumption = avgFuelConsumption;
            MaxFuelVolume = maxFuelVolume;
        }

        public virtual double GetMaxTravelDistance() //km
        {
            return MaxFuelVolume / AvgFuelConsumption * 100;
        }

        public virtual double GetTravelDistance() //km
        {
            return FuelVolume / AvgFuelConsumption * 100;
        }

        public TimeSpan GetTravelTime(double distance) 
        {
            double maxDistanse = GetTravelDistance();

            if (distance > maxDistanse)
                throw new CarException("Too many travel distanse.");

            if (Speed == 0)
                throw new CarException("Current speed is 0.");

            return TimeSpan.FromHours(distance/Speed);
        }
    }

    public class CarException : Exception
    {
        public CarException(string message) : base(message)
        {
            //
        }
    }
}
