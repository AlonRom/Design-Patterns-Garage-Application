using System;
using System.Collections.Generic;
using GarageLogic.Interfaces;
using GarageLogic.Models;

namespace GarageLogic.Operations
{
    public class DisplayVehicleFullDataOperation : Operation
    {
        private int m_LicenseNumber;
        public DisplayVehicleFullDataOperation(IGarageManager i_GarageManager)
        {
            m_GarageManager = i_GarageManager;
            Index = 7;
            Details = "View full vehicle data";

            Instructions = new Dictionary<string, Func<string, eOperationStatus>>
            {
                ["Please enter a vehicle license number"] = i_LicenseNumber => insertLicenseNumber(i_LicenseNumber),
            };
        }

        private eOperationStatus insertLicenseNumber(string i_LicenseNumber)
        {
            m_LicenseNumber = m_GarageManager.GetParsedLicenseNumber(i_LicenseNumber);
            if (m_GarageManager.CheckIfLicenseNumberExists(m_LicenseNumber))
            {
                Vehicle vehicle = m_GarageManager.GetVehiclesByLicenseNumber(m_LicenseNumber);
                m_OperationResult = m_GarageManager.GetVehicleFullData(vehicle);
            }

            return eOperationStatus.Completed;
        }
    }
}
