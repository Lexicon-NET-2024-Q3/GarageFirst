class GarageHandler : IHandler
{
    private Garage<IVehicle> garage;
    private bool hasPopulated = false;

    public GarageHandler(uint capacity)
    {
        garage = new Garage<IVehicle>(capacity);
    }

    //public void ResetGarage(uint capacity)
    //{
    //    garage = new Garage<IVehicle>(capacity);
    //}

    public void ListAllVehicles()
    {
        //Return
        // garage.Select(v => v.ToString()); // $"{v.RegNr}");
        garage.ToList().ForEach(Console.WriteLine);
    }

    public int AddVehicle(IVehicle vehicle)
    {
        //Is garage full?
            var alreadyExistsCheck = garage.FirstOrDefault(v => v.RegNr == vehicle.RegNr);
            if (alreadyExistsCheck == null)
            {
                return garage.Add(vehicle);
            }
            else
            {
                return -2;
            }
    }

    public int RemoveVehicle(string regNr)
    {
            return garage.Remove(regNr);
    }

    public void FindByRegNr(string regNr)
    {
       
            var vehicle = garage.Find(regNr);
            if (vehicle == null)
            {
                System.Console.WriteLine(
                    $"Could not find a vehicle with registration number {regNr}"
                );
            }
            else
            {
                System.Console.WriteLine(vehicle.ToString());
            }
        
      
    }

    public void ListVehiclesByCategory()
    {

        //var res = garage.GroupBy(v => v.GetType().Name)
        //                .Select(g => new ListVehicle{ VehicleType = g.Key, Count = g.Count() });

        int cars = 0;
            int boats = 0;
            int airplanes = 0;
            int motorcycles = 0;
            int buses = 0;
        foreach (var item in garage)
        {
            {
                switch (item.GetType().Name)
                {
                    case "Car":
                        cars++;
                        break;
                    case "Bus":
                        buses++;
                        break;
                    case "Airplane":
                        airplanes++;
                        break;
                    case "Motorcycle":
                        motorcycles++;
                        break;
                    case "Boat":
                        boats++;
                        break;

                    default:
                        break;
                }
            }

        }
            System.Console.WriteLine(
                $"Cars: {cars}; Buses: {buses}; Motorcycles: {motorcycles}; Boats: {boats}; Airplanes: {airplanes}"
            );
        
     
    }

    public void PopulateGarage()
    {
      
            if (hasPopulated)
            {
                System.Console.WriteLine("The garage has already been populated");
                return;
            }
            IVehicle[] vehicles =
            {
                new Car("abc123", 4, "red", FuelType.Gasoline),
                new Car("edfd123", 4, "blue", FuelType.Gasoline),
                new Car("bhg123", 4, "green", FuelType.Diesel),
                new Bus("thr432", 8, "red", 40),
                new Motorcycle("lkj543", 2, "black", 200),
                new Boat("oky543", 0, "white", 20),
                new Airplane("lkg966", 3, "white", 30.5)
            };
            garage.Populate(vehicles);
            hasPopulated = true;
            System.Console.WriteLine("Garage successfully populated");
    
    }

    public void SearchByProps(string vehicleType, string color, uint? wheelCount)
    {
    
            var targetVehicles = garage.SearchByProps(vehicleType, color, wheelCount);

            if (!targetVehicles.Any())
            {
                System.Console.WriteLine("No vehicles found matching those descriptions");
            }
            else
            {
                foreach (var item in targetVehicles)
                {
                    if (item != null)
                    {
                        System.Console.WriteLine(item.ToString());
                    }
                }
            }
    }
}
