using System;
using System.Collections.Generic;
using System.Linq;
using GarageLogic.Interfaces;
using GarageLogic.Models;
using GarageLogic.Operations.InsertNewVehicleSubOperations;

namespace GarageLogic.Operations
{
    public class InsertNewVehicleOperation : Operation
    {
        public InsertNewVehicleOperation(IGarageManager i_GarageManager)
        {
            m_GarageManager = i_GarageManager;
            Index = 1;
            Details = "Insert a new vehicle";

            Instructions = new Dictionary<string, Func<string, eOperationStatus>>
            {
                ["Please enter 1 for regular motorcycle\n" +
                 "Please enter 2 for electric motorcycle\n" + 
                 "Please enter 3 for regular car\n" +
                 "Please enter 4 for electric car\n" +
                 "Please enter 5 for truck"] = i_VehicleType => insertNewVehicle(i_VehicleType)
            };
        }

        private eOperationStatus insertNewVehicle(string i_VehicleType)
        {
            Vehicle vehicle = m_GarageManager.GetVehicleType(i_VehicleType);

            BaseInsertNewVehicleSubOperations subOperation = m_GarageManager.GetSubOperation(vehicle.GetType().Name).FirstOrDefault();
            if(subOperation != null)
            {
                subOperation.Vehicle = vehicle;
                SubMenuInstructions = subOperation.SubMenuInstructions;
                m_OperationResult = $"A new vehicle with was added successfully to the system!";
                return eOperationStatus.CanProceedToSubMenu;
            }

            return eOperationStatus.Starting;
        }
    }
}
