using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Exercise5Garage
{
    internal class ConsoleUI
    { // Create a Garage Handler
        static GarageHandler garageHandler = new GarageHandler();

        //  Main Menu for Garage 
        static public void MainMenu()
        {
            Console.Clear();
            var inputforMainMenu = Utils.AskForNumber("Please select a valid option from the following menu:"
                + "\n1. Create a new garage"
                + "\n0. Close the app");

            switch (inputforMainMenu)
            {
                case 1:
                    OpenNewGarage();
                    break;
                case 0:
                    return;
                default:
                    Console.WriteLine("Please enter a valid option!\n");
                    MainMenu();
                    break;
            }

        }

        private static void OpenNewGarage()
        {
            while (true)
            {
                Console.Clear();
                string inputName = Utils.AskForInput("Please enter the name of your garage:\n"
                    + "(Press 0 if you want to go back)");
                if (inputName == "0") MainMenu();

                uint inputCapacity = Utils.AskForNumber("Write the capacity of the garage:\n"
                    + "(Press 0 to if you want to cancel and go back)");
                if (inputCapacity == 0) MainMenu();

                var garage = garageHandler.CreateGarage(inputName, inputCapacity);

                Console.WriteLine($"Garage \"{garage.Name}\" with a Maximum capacity of {garage.Capacity} has been created!");               
                GarageMenu(garage);
                break;
            }
        }

        private static void GarageMenu(Garage<Vehicle> garage)
        {
            Console.WriteLine();
            var garageMenuInput = Utils.AskForNumber("________________________________"
                + "\nPlease select a desired option from the following Menu:"
                + "\n1 - List all parked vehicles in the Garage"
                + "\n2 - Park a vehicle in the Garage"
                + "\n0 - Go back to main menu"
                + "\n___________________________________");

            switch (garageMenuInput)
            {
                case 1:
                    garageHandler.ListParkedVehicles(garage);
                    GarageMenu(garage);
                    break;

                case 2:
                    CreateAndParkVehicleMenu(garage);
                    break;

                case 0:
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("Your selection is not valid, Please press any key to continue and  choose a valid option from the menu!\n");
                    Console.ReadKey();
                    GarageMenu(garage);
                    break;
            }
        }

        private static void CreateAndParkVehicleMenu(Garage<Vehicle> garage)
        {
            var input = Utils.AskForNumber("Select the vehicle type you want to park"
               + "\n1 - Airplane"
               + "\n2 - Motorcycle"
               + "\n3 - Car"
               + "\n4 - Bus"
               + "\n5 - Boat"
               + "\n0. Go back to the garage menu"
               + "\n ____________________________");

            var RegNr = "Registration number:";
            var Color = "Color:";
            var Manufacturer = "Manufacturer:";
            var NumberOfWheels = "Number of wheels:";            
            var ProductionYear = "Year of production:";

            switch (input)
            {
                case 1:
                    var airplane = new Airplane(
                        regNr: Utils.AskForInput(RegNr),
                        manufacturer: Utils.AskForInput(Manufacturer),
                        numberOfWheels: Utils.AskForNumber(NumberOfWheels),
                        color: Utils.AskForInput(Color),
                        productionYear: Utils.AskForNumber(ProductionYear),
                        numberOfEngines: Utils.AskForNumber("Number of engines:")
                        );
                        garageHandler.ParkVehicle(garage, airplane);
                        CreateAndParkVehicleMenu(garage);
                    break;
                case 2:
                    var motorcycle = new Motorcycle(
                        regNr: Utils.AskForInput(RegNr),
                        manufacturer: Utils.AskForInput(Manufacturer),
                        numberOfWheels: Utils.AskForNumber(NumberOfWheels),
                        color: Utils.AskForInput(Color),
                        productionYear: Utils.AskForNumber(ProductionYear),
                        cylinderVolume: Utils.AskForNumber("Cylinder volume:")
                            );
                        garageHandler.ParkVehicle(garage, motorcycle);
                        CreateAndParkVehicleMenu(garage);
                    break;
                case 3:
                    var car = new Car(
                        regNr: Utils.AskForInput(RegNr),
                        manufacturer: Utils.AskForInput(Manufacturer),
                        numberOfWheels: Utils.AskForNumber(NumberOfWheels),
                        color: Utils.AskForInput(Color),
                        productionYear: Utils.AskForNumber(ProductionYear),
                        fuelType: Utils.AskForInput("Fuel type:")
                            );
                        garageHandler.ParkVehicle(garage, car);
                        CreateAndParkVehicleMenu(garage);
                    break;
                    
                case 4:
                    var bus = new Bus(
                        regNr: Utils.AskForInput(RegNr),
                        manufacturer: Utils.AskForInput(Manufacturer),
                        numberOfWheels: Utils.AskForNumber(NumberOfWheels),
                        color: Utils.AskForInput(Color),
                        productionYear: Utils.AskForNumber(ProductionYear),
                        numberOfSeats: Utils.AskForNumber("Number of seats:")
                            );
                        garageHandler.ParkVehicle(garage, bus);
                        CreateAndParkVehicleMenu(garage);
                    break;
                
                case 5:
                    var boat = new Boat(
                        regNr: Utils.AskForInput(RegNr),
                        manufacturer: Utils.AskForInput(Manufacturer),
                        numberOfWheels: Utils.AskForNumber(NumberOfWheels),
                        color: Utils.AskForInput(Color),
                        productionYear: Utils.AskForNumber(ProductionYear),
                        length: Utils.AskForNumber("Length:")
                            );
                        garageHandler.ParkVehicle(garage, boat);
                        CreateAndParkVehicleMenu(garage);
                    break;
                case 0:
                        GarageMenu(garage);
                    break;
                default:
                        Console.WriteLine("Please select a valid option!\n");
                        CreateAndParkVehicleMenu(garage);
                    break;
            }
        }


        internal static void ShowParkedVehicles(IEnumerable<Garage<Vehicle>.ExportedListOfVehicles> parkedVehicles)
        {
            if (!parkedVehicles.Any())
            {
                Console.WriteLine("The garage is empty or Registration Number is already Used.");
            }
            else
            {
                Console.WriteLine("\nThe parked vehicles in the garage are:");
                foreach (var item in parkedVehicles)
                {
                    Console.WriteLine("\nParking Place Nr: " + item.ParkingPlace
                        + "\nVehicle Type: " + item.TypeOfVehicle
                        + "\nRegistration Number: " + item.RegNr
                        + "\nColor: " + item.Color
                        + "\nManufacturer: " + item.Manufacturer
                        + "\nNumber of Wheels: " + item.NumberOfWheels                        
                        + "\nProduction Year: " + item.ProductionYear
                        + "\n_______________________________");
                }
            }
        }

        public static void SuccessParkedMessage()
        {
            Console.WriteLine("The vehicle was successfully parked!\n");
        }

        internal static void FailedParkedMessage()
        {
            Console.WriteLine("The garage is full or there is already another vehicle with same registration number!\n");
        }

    }
}