using System;
using System.Collections.Generic;
using GarageLogic.Interfaces;
using GarageLogic.Models;

namespace GarageLogic.Operations
{
    public class ChangeVehicleConditionOperation : Operation
    {
        private int m_LicenseNumber;
        public ChangeVehicleConditionOperation(IGarageManager i_GarageManager)
        {
            m_GarageManager = i_GarageManager;
            Index = 3;
            Details = "Change the condition of a vehicle in the garage";

            Instructions = new Dictionary<string, Func<string, eOperationStatus>>
            {
                ["Please enter a vehicle license number"] = i_LicenseNumber => insertLicenseNumber(i_LicenseNumber),
                ["Please enter 1 to change state to - during fix\n" +
                 "Please enter 2 to change state to - fix\n" +
                 "Please enter 3 to change state to - paid\n"] = i_VehicleState => changeVehicleState(i_VehicleState),
            };

        }

        private eOperationStatus insertLicenseNumber(string i_LicenseNumber)
        {
            m_LicenseNumber = m_GarageManager.GetParsedLicenseNumber(i_LicenseNumber);
            return m_GarageManager.CheckIfLicenseNumberExists(m_LicenseNumber) ? 
                                                    eOperationStatus.CanProceed : 
                                                    eOperationStatus.Starting;
        }


        private eOperationStatus changeVehicleState(string i_VehicleState)
        {
            int newVehicleState;
            if (!int.TryParse(i_VehicleState, out newVehicleState))
            {
                throw new FormatException("The state you entered is not legal! Please try again");
            }
            if (newVehicleState < 1 || newVehicleState > 3)
            {
                throw new ArgumentException("The state you entered doesn't exists! Please try again");
            }

            m_GarageManager.SetVehicleState(m_LicenseNumber, (eVehicleState)newVehicleState);
            m_OperationResult = $"Vehicle {m_LicenseNumber} state was changed to {(eVehicleState)newVehicleState} successfully!";
            return eOperationStatus.Completed;
        }
    }
}
