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
            var inputForMainMenu = Utils.AskForNumber("###########################################\n" +
                "\nPlease select a valid option from the following menu:\n"                 
                + "\n1 - Create a new garage"
                + "\n0 - Close the app \n" +
                "\n###########################################");

            switch (inputForMainMenu)
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
                string inputName = Utils.AskForInput("\n_____________________________\n" +
                    "Please enter the name of your garage:\n"
                    + "(Press 0 if you want to go back to Main Menu)");
                if (inputName == "0") MainMenu();

                uint inputCapacity = Utils.AskForNumber("Write the capacity of the garage:\n"
                    + "(Press 0 to if you want to cancel and go back to Main Menu)");
                if (inputCapacity == 0) MainMenu();

                Console.WriteLine("_____________________________\n");
                var garage = garageHandler.CreateGarage(inputName, inputCapacity);
                
                Console.WriteLine("Your Garage has been created " +
                    "\n_________________________________________\n");

                              
                GarageMenu(garage);
                break;
            }
        }

        private static void GarageMenu(Garage<Vehicle> garage)
        {
            Console.WriteLine($"" +
                $"###########################################" +
                $"\n Welcome to \"{garage.Name}'s\" Garage" +
                    $"\n This garage has maximum {garage.Capacity} Places." +
                    $"\n#######################################");
            var garageMenuInput = Utils.AskForNumber(
                "\nPlease select a desired option from the following Menu:\n"
                + "\n1 - List all parked vehicles in the Garage"
                + "\n2 - Park a vehicle in the Garage"
                + "\n3 - UnPark a vehicle in the Garage"
                + "\n4 - Search a vehicle in the Garage by registration number"
                + "\n5 - Search a vehicle in the Garage by Type"
                + "\n0 - Go back to main menu"
                + "\n___________________________________\n");

            switch (garageMenuInput)
            {
                case 1:
                    garageHandler.ListParkedVehicles(garage);
                    GarageMenu(garage);                    
                    break;

                case 2:
                    ParkAVehicleMenu(garage);
                    break;
                case 3:
                    garageHandler.UnParkVehicle(garage, Utils.AskForInput("Please " +
                        "enter the Registration Number of Vehicle to be Unparked from Garage:"));
                    GarageMenu(garage);
                    break;
                case 4:
                    garageHandler.SearchVehicleByRegNr(garage, Utils.AskForInput("Please enter the " +
                        "registration number of Vehicle you want to search in the garage:"));
                    GarageMenu(garage);
                    break;
                case 5:
                    garageHandler.SearchVehicleByType(garage);
                    GarageMenu(garage);
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

        private static void ParkAVehicleMenu(Garage<Vehicle> garage)
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
                        ParkAVehicleMenu(garage);
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
                        ParkAVehicleMenu(garage);
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
                        ParkAVehicleMenu(garage);
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
                        ParkAVehicleMenu(garage);
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
                        ParkAVehicleMenu(garage);
                    break;
                case 0:
                        GarageMenu(garage);
                    break;
                default:
                        Console.WriteLine("Please select a valid option!\n");
                        ParkAVehicleMenu(garage);
                    break;
            }
        }


        internal static void ShowParkedVehicles(IEnumerable<Garage<Vehicle>.ExtractedListOfVehicles> parkedVehicles)
        {
            if (!parkedVehicles.Any())
            {
                Console.WriteLine("The garage is empty.");
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

        //Group collection of objects that have a common key (Type)
        internal static void ShowVehiclesTypes(IEnumerable<IGrouping<string, Vehicle>> listOfVehiclesByType)
        {
            foreach (var item in listOfVehiclesByType)
            {
                if (string.IsNullOrEmpty(item.Key)) { }
                else
                {
                    Console.WriteLine("The garage contains {0} number of vehicles of Type: {1}",
                        item.Count(),
                        item.Key);
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

        public static void SuccessUnparkMessage(string RegNr)
        {
            Console.WriteLine($"The vehicle with Registration Number \" {RegNr} \" was successfully unparked from the garage!\n");
        }

        internal static void FailedUnparkMessage(string RegNr)
        {
            Console.WriteLine($"The vehicle was not found in the garage with Registration Number \" {RegNr} \"\n");
        }

        internal static void SuccessFoundVehicle(string RegNr)
        {
            Console.WriteLine($"The vehicle found in the garage with Registration Number \" {RegNr} \"\n");
        }

        internal static void FailedFoundVehicle(string RegNr)
        {
            Console.WriteLine($"The vehicle was not found in the garage with Registration Number \" {RegNr} \"\n");
        }
    }
}