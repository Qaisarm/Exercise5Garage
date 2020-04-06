namespace Exercise5Garage
{
    class Car : Vehicle
    {
        public Car(string regNr, string color, uint numberOfWheels, string manufacturer, uint productionYear, string fuelType) : base(regNr, color, numberOfWheels, manufacturer, productionYear)
        {
            FuelType = fuelType;
        }

        public string FuelType { get; private set; }
    }
}

