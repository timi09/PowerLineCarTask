namespace PowerLineCarTask.Cars
{
    public class SportCar : PassengerCar
    {
        public SportCar(VehicleType type, double avgFuelConsumption, double maxFuelVolume, bool hasPassengerSeat) : base(type, avgFuelConsumption, maxFuelVolume, hasPassengerSeat? 1 : 0) 
        {
        
        }
    }
}
