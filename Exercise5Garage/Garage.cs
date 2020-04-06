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

        // Internal subclass for exporting the parked vehicle collection to the ConsoleUI
        internal class ExportedListOfVehicles
        {
             internal int ParkingPlace { get; set; }

            internal string TypeOfVehicle { get; set; }

            internal string RegNr { get; set; }
            internal string Color { get; set; }
            internal string Manufacturer { get; set; }
            internal uint NumberOfWheels { get; set; }
            internal uint ProductionYear { get; set; }
           
        }

        internal IEnumerable<ExportedListOfVehicles> ListParkedVehicles()
        {
            var result = ParkedVehicles
            .Where(v => v != null)
            .Select(v => new ExportedListOfVehicles
            {
                ParkingSpot = Array.IndexOf(ParkedVehicles, v) + 1,
                TypeOfVehicle = v.GetType().Name,
                RegNr = v.RegNr,
                Manufacturer = v.Manufacturer,
                NumberOfWheels = v.NumberOfWheels,
                Color = v.Color,
                ProductionYear = v.ProductionYear
            });

            return result;
        }

        internal bool ParkVehicle(Vehicle vehicle)
        {
            if (IsFull) return false;
            // Find an index to park the vehicle (if index is null or there is no regnumber property)
            int index = Array.FindIndex(ParkedVehicles, i => i == null);
            ParkedVehicles[index] = vehicle;
            return true;
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