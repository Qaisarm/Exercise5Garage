using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Exercise5Garage
{
    public class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        public string Name;
        public static uint Maxcapacity;

        private Vehicle[] ParkedVehicles;

        public readonly uint Capacity;

        public int Count => ParkedVehicles.Count(i => i != null);

        public bool IsFull => Maxcapacity <= Count;
        public Garage(string name, uint maxcapacity)
        {
            Name = name;
            Maxcapacity = maxcapacity;
            Capacity = maxcapacity;
            ParkedVehicles = new Vehicle[Maxcapacity];
        }

        // Internal subclass for extracting the parked vehicle collection to the ConsoleUI
        internal class ExtractedListOfVehicles
        {
             internal int ParkingPlace { get; set; }

            internal string TypeOfVehicle { get; set; }

            internal string RegNr { get; set; }
            internal string Color { get; set; }
            internal string Manufacturer { get; set; }
            internal uint NumberOfWheels { get; set; }
            internal uint ProductionYear { get; set; }
           
        }

        internal IEnumerable<ExtractedListOfVehicles> ListParkedVehicles()
        {
            var result = ParkedVehicles
            .Where(v => v != null)
            .Select(v => new ExtractedListOfVehicles
            {
                ParkingPlace = Array.IndexOf(ParkedVehicles, v) + 1,
                TypeOfVehicle = v.GetType().Name,
                RegNr = v.RegNr,
                Color = v.Color,
                Manufacturer = v.Manufacturer,
                NumberOfWheels = v.NumberOfWheels,               
                ProductionYear = v.ProductionYear
            });

            return result;
        }

        internal bool ParkVehicle(Vehicle vehicle)
        {
            if (IsFull || SearchVehicleByRegNr(vehicle.RegNr)) return false;
            // Find an index to park the vehicle (if index is null or there is no Registration Number)
            int index = Array.FindIndex(ParkedVehicles, i => i == null || string.IsNullOrEmpty(i.RegNr));
            ParkedVehicles[index] = vehicle;
            return true;
        }

        internal bool UnParkVehicle(string regNr)
        {
            // Find an index to unpark the vehicle (if index is not null and convert registration number to lower case)
            int index = Array.FindIndex(ParkedVehicles, i => i != null && i.RegNr.ToLower() == regNr.ToLower());

            if (index >= 0)
            {
                ParkedVehicles[index] = null;
                return true;
            }

            return false;
        }
        internal bool SearchVehicleByRegNr(string regNr)
        {
            var regNrMatched = ParkedVehicles.FirstOrDefault(v => v != null && v.RegNr.ToLower() == regNr.ToLower());

            if (regNrMatched != null)
            {
                return true;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in ParkedVehicles)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}