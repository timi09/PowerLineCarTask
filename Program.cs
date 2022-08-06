using PowerLineCarTask.Cars;

namespace PowerLineCarTask
{
    class Program
    {
        static void Main(string[] args)
        {
            SportCar sc = new SportCar(VehicleType.PassengerCar, 10, 30, true);

            sc.Speed = 120;

            sc.AddPassenger(new Person("A"));

            double distanse = sc.GetMaxTravelDistance();

            sc.RemovePassenger();

            distanse = sc.GetMaxTravelDistance();

            //
            Truck truck = new Truck(VehicleType.Truck, 10, 100, 1000);

            truck.LoadCargo(200);

            distanse = truck.GetMaxTravelDistance();

            distanse = truck.GetTravelDistance();

            truck.FuelVolume = 50;

            distanse = truck.GetTravelDistance();

            //
            PassengerCar car = new PassengerCar(VehicleType.PassengerCar, 7, 60, 4);

            car.AddPassenger(new Person("A"));
            car.AddPassenger(new Person("B"));
            car.AddPassenger(new Person("C"));

            distanse = car.GetMaxTravelDistance();

            car.RemovePassenger();

            distanse = car.GetTravelDistance();

            car.FuelVolume = 50;

            distanse = truck.GetTravelDistance();
        }
    }
}