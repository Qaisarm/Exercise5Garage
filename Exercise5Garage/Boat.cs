namespace Exercise5Garage
{
    class Boat : Vehicle
    {
        public Boat(string regNr, string color, uint numberOfWheels, string manufacturer, uint productionYear, uint length) : base(regNr, color, numberOfWheels, manufacturer, productionYear)
        {
            Length = length;
        }

        public uint Length { get; private set; }
    }
}
