namespace Exercise5Garage
{
    class Motorcycle : Vehicle
    {
        public Motorcycle(string regNr, string color, uint numberOfWheels, string manufacturer, uint productionYear, uint cylinderVolume) : base(regNr, color, numberOfWheels, manufacturer, productionYear)
        {
            CylinderVolume = cylinderVolume;
        }

        public uint CylinderVolume { get; private set; }
    }
}