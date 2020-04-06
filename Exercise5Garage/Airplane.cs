namespace Exercise5Garage
{
    class Airplane : Vehicle
    {
        public Airplane(string regNr, string color, uint numberOfWheels, string manufacturer, uint productionYear, uint numberOfEngines) : base(regNr, color, numberOfWheels, manufacturer, productionYear)
        {
            NumberOfEngines = numberOfEngines;
        }

        public uint NumberOfEngines { get; private set; }
    }
}
