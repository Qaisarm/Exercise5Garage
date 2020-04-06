namespace Exercise5Garage
{
     class Bus : Vehicle
    {
        public Bus(string regNr, string color, uint numberOfWheels, string manufacturer, uint productionYear, uint numberOfSeats) : base(regNr, color, numberOfWheels, manufacturer, productionYear)
        {
            NumberOfSeats = numberOfSeats;
        }

        public uint NumberOfSeats { get; private set; }
    }
}
