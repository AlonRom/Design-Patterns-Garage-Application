using System;
using System.Collections.Generic;
using GarageLogic.Interfaces;
using GarageLogic.Models;

namespace GarageLogic.Operations
{
    public class DisplayVehiclesLicenseNumberOperation : Operation
    {
        public DisplayVehiclesLicenseNumberOperation(IGarageManager i_GarageManager)
        {
            m_GarageManager = i_GarageManager;
            Index = 2;
            Details = "Display the list of vehicle license numbers in the garage";

            Instructions = new Dictionary<string, Func<string, eOperationStatus>>
            {
                ["Please enter 1 to get all vehicles during fix\n" +
                 "Please enter 2 to get all fixed vehicles\n" +
                 "Please enter 3 to get all paid vehicles\n" +
                 "Please enter * to get all vehicles\n"] = i_VehiclesFilter => getVehicles(i_VehiclesFilter)
            };
        }

        private eOperationStatus getVehicles(string i_VehiclesFilter)
        {
            int filterByIndex;
            if (!int.TryParse(i_VehiclesFilter, out filterByIndex) && i_VehiclesFilter != "*")
            {
                throw new FormatException("The filter you entered is not legal! Please try again");
            }

            if (i_VehiclesFilter == "*")
            {
                m_OperationResult = string.Join(", ", m_GarageManager.GetAllVehiclesLicenseNumber());
                return eOperationStatus.Completed;
            }

            if (filterByIndex < 1 || filterByIndex > 3)
            {
                throw new ArgumentException("The filter you entered doesn't exists! Please try again");
            }

            m_OperationResult = string.Join(", ", m_GarageManager.GetVehiclesLicenseNumberByState((eVehicleState)filterByIndex));
            return eOperationStatus.Completed;
        }
    }
}
