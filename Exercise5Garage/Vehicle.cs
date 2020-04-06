namespace Exercise5Garage
{
    public class Vehicle
    {
        public Vehicle(string regNr, string color, uint numberOfWheels, string manufacturer, uint productionYear)
        {
            RegNr = regNr;
            Color = color;
            NumberOfWheels = numberOfWheels;
            Manufacturer = manufacturer;
            ProductionYear = productionYear;
        }



        public string RegNr { get; private set; }
        public string Color { get; private set; }
        public uint NumberOfWheels { get; private set; }
        public string Manufacturer { get; private set; }
        public uint ProductionYear { get; private set; }
    }
}
