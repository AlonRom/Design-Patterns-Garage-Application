﻿using System;
using System.Collections.Generic;
using GarageLogic.Interfaces;
using GarageLogic.Models;

namespace GarageLogic.Operations.InsertNewVehicleSubOperations
{
    public abstract class  BaseInsertNewVehicleSubOperations : BaseOperation
    {
        private string m_ModelName;
        private string m_OwnerName;
        private string m_OwnerPhone;
        private int m_LicenseNumber;
        private string m_WheelsManufacturerName;
        private float m_WheelsMaxPressure;

        public Vehicle Vehicle { get; set; }

        protected BaseInsertNewVehicleSubOperations(IGarageManager i_GarageManager)
        {
            m_GarageManager = i_GarageManager;
            SubMenuInstructions = new Dictionary<string, Func<string, eOperationStatus>>
            {
                ["Please enter model name"] = i_ModelName => insertModelName(i_ModelName),
                ["Please enter your name"] = i_OwnerName => insertOwnerName(i_OwnerName),
                ["Please enter your phone number"] = i_OwnerPhone => insertOwnerPhone(i_OwnerPhone),
                ["Please enter a license number for the new vehicle"] = i_LicenseNumber => insertLicenseNumber(i_LicenseNumber),
            };
        }

        protected void AddWheelsInstructions(int i_NumberOfWheels, float i_WheelsMaxPressure)
        {
            m_WheelsMaxPressure = i_WheelsMaxPressure;
            SubMenuInstructions.Add("Please enter wheels manufacturer name", insertWheelsManufacturerName);
            for(int i = 1; i <= i_NumberOfWheels; i++)
            {
                SubMenuInstructions.Add("Please enter current wheel pressure between 0 to " + i_WheelsMaxPressure + " for wheel number " + i, insertWheelCurrentPressure);
            }
        }

        protected virtual void InsertNewVehicle()
        {
            Vehicle.LicenseNumber = m_LicenseNumber;
            Vehicle.ModelName = m_ModelName;
            m_GarageManager.InsertNewVehicle(m_LicenseNumber, m_OwnerName, m_OwnerPhone, Vehicle);
        }
        private eOperationStatus insertModelName(string i_ModelName)
        {
            m_ModelName = i_ModelName;
            return eOperationStatus.CanProceed;
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
                throw new FormatException("The phone number you entered is not legal! Please try again");
            }
            m_OwnerPhone = i_OwnerPhone;
            return eOperationStatus.CanProceed;
        }

        private eOperationStatus insertLicenseNumber(string i_LicenseNumber)
        {
            m_LicenseNumber = m_GarageManager.GetParsedLicenseNumber(i_LicenseNumber);

            if (m_GarageManager.GetGarageVehicles().ContainsKey(m_LicenseNumber))
            {
                m_GarageManager.SetVehicleState(m_LicenseNumber, eVehicleState.DuringFix);
                throw new ArgumentException("The license number you entered already exists in our system, We will start fixing it now!");
            }
            return eOperationStatus.CanProceed;
        }

        private eOperationStatus insertWheelsManufacturerName(string i_WheelsManufacturerName)
        {
            m_WheelsManufacturerName = i_WheelsManufacturerName;
            return eOperationStatus.CanProceed;
        }

        private eOperationStatus insertWheelCurrentPressure(string i_WheelsCurrentPressure)
        {
            float currentWheelPressureToInsert;
            if (!float.TryParse(i_WheelsCurrentPressure, out currentWheelPressureToInsert))
            {
                throw new FormatException("The wheel pressure you entered is not legal! Please try again");
            }

            Vehicle.Wheels.Add(new Wheel(m_WheelsManufacturerName, currentWheelPressureToInsert, m_WheelsMaxPressure));

            return eOperationStatus.CanProceed;
        }
    }
}
