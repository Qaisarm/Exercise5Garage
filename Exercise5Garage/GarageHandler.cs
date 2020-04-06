using System;
using System.Collections.Generic;

namespace Exercise5Garage
{
    internal class GarageHandler : IGarageHandler
    {
        public Garage<Vehicle> CreateGarage(string name, uint maxcapacity)
        {
            return new Garage<Vehicle>(name, maxcapacity);
        }



        public void ListParkedVehicles(Garage<Vehicle> garage)
        {
            ConsoleUI.ShowParkedVehicles(garage.ListParkedVehicles());
        }


        public void ParkVehicle(Garage<Vehicle> garage, Vehicle vehicle)
        {
            if (garage.ParkVehicle(vehicle)) { ConsoleUI.SuccessParkedMessage(); }
            else { ConsoleUI.FailedParkedMessage(); }
        }

        public void UnParkVehicle(Garage<Vehicle> garage, string regNr)
        {
            if (garage.UnParkVehicle(regNr)) { ConsoleUI.SuccessUnparkMessage(); }
            else { ConsoleUI.FailedUnparkMessage(); }
        }
    }
}