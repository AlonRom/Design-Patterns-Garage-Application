﻿using System;
using System.Collections.Generic;
using GarageLogic.Interfaces;
using GarageLogic.Models;

namespace GarageLogic.Operations
{
    public class InflateWheelsAirOperation : Operation
    {
        private int m_LicenseNumber;
        public InflateWheelsAirOperation(IGarageManager i_GarageManager)
        {
            m_GarageManager = i_GarageManager;
            Index = 4;
            Details = "Inflate the air in the wheels of a vehicle to a maximum";

            Instructions = new Dictionary<string, Func<string, eOperationStatus>>
            {
                ["Please enter a vehicle license number"] = i_LicenseNumber => insertLicenseNumber(i_LicenseNumber),
            };
        }

        private eOperationStatus insertLicenseNumber(string i_LicenseNumber)
        {
            m_LicenseNumber = m_GarageManager.GetParsedLicenseNumber(i_LicenseNumber);
            if(m_GarageManager.CheckIfLicenseNumberExists(m_LicenseNumber))
            {
                Vehicle vehicle = m_GarageManager.GetVehiclesByLicenseNumber(m_LicenseNumber);

                inflateVehicleWheels(vehicle);
            }

            m_OperationResult = $"Vehicle {m_LicenseNumber} wheels infalted successfully!";
            return eOperationStatus.Completed;
        }

        private static void inflateVehicleWheels(Vehicle i_Vehicle)
        {
            foreach(Wheel vehicleWheel in i_Vehicle.Wheels)
            {
                vehicleWheel.InflateWheel(vehicleWheel.MaxAirPressureByManufacturer - vehicleWheel.CurrentAirPressure);
            }
        }
    }
}
