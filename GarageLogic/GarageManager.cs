using System;
using System.Collections.Generic;
using System.Linq;
using GarageLogic.Interfaces;
using GarageLogic.Models;

namespace GarageLogic
{
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

        public void InsertNewVehicle(int i_LicenseNumber, string i_OwnerName, string i_OwnerPhone)
        {            
            r_GarageVehicles.Add(i_LicenseNumber, new GarageVehicle { OwnerName = i_OwnerName, OwnerPhone = i_OwnerPhone, VehicleState = eVehicleState.DuringFix });
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
    }
}
