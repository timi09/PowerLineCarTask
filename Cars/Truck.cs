namespace PowerLineCarTask.Cars
{
    public class Truck : Car
    {
        private const double Slowdown = 0.04;

        private const double WeightForSlowdown = 200;

        public readonly double MaxCargoWeight; //kg

        public double CargoWeight { get; private set; } //kg

        public Truck(VehicleType type, double avgFuelConsumption, double maxFuelVolume, double maxCargoWeight) : base(type, avgFuelConsumption, maxFuelVolume)
        {
            if (maxCargoWeight < 0)
                throw new TruckException("Max cargo weight must not be negative.");

            MaxCargoWeight = maxCargoWeight;
            CargoWeight = 0;
        }

        public bool IsHasSpace(double weight) 
        {
            if (weight < 0)
                throw new TruckException("Weight must not be negative.");

            return CargoWeight + weight <= MaxCargoWeight;
        }

        public void LoadCargo(double weight)
        {
            if (!IsHasSpace(weight))
                throw new TruckException("Too many weight.");

            CargoWeight += weight;
        }

        public void UnloadCargo(double weight)
        {
            if (weight < 0)
                throw new TruckException("Weight must not be negative.");

            CargoWeight -= weight;

            if (CargoWeight < 0)
                CargoWeight = 0;
        }

        public override double GetMaxTravelDistance()
        {
            double distanse = base.GetMaxTravelDistance();

            return distanse * Math.Pow(1.0 - Slowdown, CargoWeight / WeightForSlowdown);
        }

        public override double GetTravelDistance()
        {
            double distanse = base.GetTravelDistance();

            return distanse * Math.Pow(1.0 - Slowdown, CargoWeight / WeightForSlowdown);
        }
    }


    public class TruckException : CarException
    {
        public TruckException(string message) : base(message)
        {
            //
        }
    }
}
