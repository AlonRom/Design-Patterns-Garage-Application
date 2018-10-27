using System;
using System.Collections.Generic;
using GarageLogic.Interfaces;
using GarageLogic.Models;

namespace GarageLogic.Operations
{
    public class InsertNewVehicleOperation : Operation
    {
        private string m_OwnerName;
        private string m_OwnerPhone;

        public InsertNewVehicleOperation(IGarageManager i_GarageManager)
        {
            m_GarageManager = i_GarageManager;
            Index = 1;
            Details = "Insert a new vehicle";

            Instructions = new Dictionary<string, Func<string, eOperationStatus>>
            {
                ["Please enter your name"] = i_OwnerName => insertOwnerName(i_OwnerName),
                ["Please enter your phone number"] = i_OwnerPhone => insertOwnerPhone(i_OwnerPhone),
                ["Please enter a license number for the new vehicle"] = i_LicenseNumber => insertNewVehicle(i_LicenseNumber)
            };
        }

        private eOperationStatus insertOwnerName(string i_OwnerName)
        {
            m_OwnerName = i_OwnerName;
            return eOperationStatus.CanProceed;
        }

        private eOperationStatus insertOwnerPhone(string i_OwnerPhone)
        {
            int phoneNumberToInsert;
            if (!int.TryParse(i_OwnerPhone, out phoneNumberToInsert))
            {
                throw new ArgumentException("The phone number you entered is not legal! Please try again");
            }
            m_OwnerPhone = i_OwnerPhone;
            return eOperationStatus.CanProceed;
        }

        private eOperationStatus insertNewVehicle(string i_LicenseNumber)
        {
            int licenseNumberToInsert;
            if (!int.TryParse(i_LicenseNumber, out licenseNumberToInsert))
            {
                throw new ArgumentException("The license number you entered is not legal! Please try again");
            }

            if(m_GarageManager.GetGarageVehicles().ContainsKey(licenseNumberToInsert))
            {
                m_GarageManager.SetVehicleState(licenseNumberToInsert, eVehicleState.DuringFix);
                throw new ArgumentException("The license number you entered already exists in our system, We will start fixing it now!");
            }

            m_GarageManager.InsertNewVehicle(licenseNumberToInsert, m_OwnerName, m_OwnerPhone);
            OperationResult = $"A new vehicle with {i_LicenseNumber} license number was added successfully to the system!";
            return eOperationStatus.Completed;
        }
    }
}
