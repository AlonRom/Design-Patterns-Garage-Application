using System;
using System.Collections.Generic;
using System.Linq;
using GarageLogic.Interfaces;
using GarageLogic.Models;
using GarageLogic.Operations;
using GarageLogic.Operations.InsertNewVehicleSubOperations;

namespace GarageLogic
{
    public enum eSupportedVehicleType
    {
        MotorcycleRegular = 1,
        MotorcycleElectric = 2,
        CarRegular = 3,
        CarElectric = 4,
        Truck = 5
    }

    public class GarageManager : IGarageManager
    {
        private readonly Dictionary<int, GarageVehicle> r_GarageVehicles;

        public GarageManager()
        { 
            r_GarageVehicles = new Dictionary<int, GarageVehicle>(); 
        }    
          
        public Dictionary<int, GarageVehicle> GetGarageVehicles()
        {
            return r_GarageVehicles;
        }

        public void SetVehicleState(int i_LicenseNumber, eVehicleState i_VehicleState)
        {
            r_GarageVehicles[i_LicenseNumber].VehicleState = i_VehicleState;
        }

        public void InsertNewVehicle(int i_LicenseNumber, string i_OwnerName, string i_OwnerPhone, Vehicle i_Vehicle)
        {            
            r_GarageVehicles.Add(i_LicenseNumber, new GarageVehicle { OwnerName = i_OwnerName, OwnerPhone = i_OwnerPhone, VehicleState = eVehicleState.DuringFix, Vehicle = i_Vehicle});
        }

        public IEnumerable<int> GetAllVehiclesLicenseNumber()
        {
            return r_GarageVehicles.Select(i_V => i_V.Key);
        }

        public IEnumerable<int> GetVehiclesLicenseNumberByState(eVehicleState i_VehicleState)
        {
            return r_GarageVehicles.Where(i_V => i_V.Value.VehicleState == i_VehicleState)
                                   .Select(i_V => i_V.Key);
        }


        public Vehicle GetVehiclesByLicenseNumber(int i_LicenseNumber)
        {
            GarageVehicle garageVehicle;
            return r_GarageVehicles.TryGetValue(i_LicenseNumber, out garageVehicle) ? garageVehicle.Vehicle : null;
        }

        public int GetParsedLicenseNumber(string i_LicenseNumber)
        {
            int licenseNumberToInsert;
            if (!int.TryParse(i_LicenseNumber, out licenseNumberToInsert))
            {
                throw new ArgumentException("The license number you entered is not legal! Please try again");
            }

            return licenseNumberToInsert;
        }

        public bool CheckIfLicenseNumberExists(int i_LicenseNumber)
        {
            if (!r_GarageVehicles.ContainsKey(i_LicenseNumber))
            {
                throw new ArgumentException("The license number you entered doesn't exists in the system! Please try again");
            }
            return true;
        }

        public Vehicle GetVehicleType(string i_VehicleType)
        {
            int vehicleType;
            if (!int.TryParse(i_VehicleType, out vehicleType))
            {
                throw new ArgumentException("The vehicle type you entered is not legal! Please try again");
            }
            if (!Enum.IsDefined(typeof(eSupportedVehicleType), vehicleType))
            {
                throw new ArgumentException("The vehicle type you entered doesn't exists! Please try again");
            }

            string vehicleTypeFullNameToCreate = AppDomain.CurrentDomain.GetAssemblies()
                                             .SelectMany(i_X => i_X.GetTypes())
                                             .Where(i_X => typeof(Vehicle).IsAssignableFrom(i_X)
                                                            && !i_X.IsInterface
                                                            && !i_X.IsAbstract
                                                            && i_X.Name == ((eSupportedVehicleType)vehicleType).ToString())
                                                           .Select(i_X => i_X.FullName).First();

            Type t = Type.GetType(vehicleTypeFullNameToCreate);
            if (t == null)
            {
                throw new ArgumentException("Failed creating vehicle type");
            }

            return (Vehicle)Activator.CreateInstance(t);
        }

        public IEnumerable<Operation> GetOperations()
        {
    
            List<string> operationsFullName = AppDomain.CurrentDomain.GetAssemblies()
                                                .SelectMany(i_X => i_X.GetTypes())
                                                .Where(i_X => typeof(Operation).IsAssignableFrom(i_X) && !i_X.IsInterface && !i_X.IsAbstract)
                                                .Select(i_X => i_X.FullName).ToList();

            foreach (string operationFullName in operationsFullName)
            {
                Type t = Type.GetType(operationFullName);
                if (t != null)
                {
                    Operation operation = Activator.CreateInstance(t, this) as Operation;
                    if (operation != null)
                    {
                        yield return operation;
                    }
                }
            }
        }

        public IEnumerable<BaseInsertNewVehicleSubOperations> GetSubOperation(string i_VehicleTypeName)
        {

            string operationFullName = AppDomain.CurrentDomain.GetAssemblies()
                                               .SelectMany(i_X => i_X.GetTypes())
                                               .Where(i_X => typeof(BaseInsertNewVehicleSubOperations).IsAssignableFrom(i_X)
                                                                                                       && !i_X.IsInterface
                                                                                                       && !i_X.IsAbstract
                                                                                                       && i_X.Name.Contains(i_VehicleTypeName))
                                               .Select(i_X => i_X.FullName).SingleOrDefault();

            if (operationFullName != null)
            {
                Type t = Type.GetType(operationFullName);
                if (t != null)
                {
                    BaseInsertNewVehicleSubOperations operation = Activator.CreateInstance(t, this) as BaseInsertNewVehicleSubOperations;
                    if (operation != null)
                    {
                        yield return operation;
                    }
                }
            }
        }
    }
}
