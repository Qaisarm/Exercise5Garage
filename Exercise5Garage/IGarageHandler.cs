namespace Exercise5Garage
{
    internal interface IGarageHandler
    {
        Garage<Vehicle> CreateGarage(string name, uint maxcapacity);
        void ListParkedVehicles(Garage<Vehicle> garage);
        void ParkVehicle(Garage<Vehicle> garage, Vehicle vehicle);
    }
}