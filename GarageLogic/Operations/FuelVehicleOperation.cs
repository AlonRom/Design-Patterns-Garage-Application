using System;
using System.Collections.Generic;
using GarageLogic.Exceptions;
using GarageLogic.Interfaces;

namespace GarageLogic.Operations
{
    public class FuelVehicleOperation : Operation
    {
        private int m_LicenseNumber;
        private eFuelType m_FuelType;
        private IRegularVehicle m_Vehicle;

        public FuelVehicleOperation(IGarageManager i_GarageManager)
        {
            m_GarageManager = i_GarageManager;
            Index = 5;
            Details = "Fuel a vehicle driven by fuel";

            Instructions = new Dictionary<string, Func<string, eOperationStatus>>
            {
                ["Please enter a vehicle license number"] = i_LicenseNumber => insertLicenseNumber(i_LicenseNumber),
                ["Please enter 1 for " + eFuelType.Octan95 + " fuel\n" +
                 "Please enter 2 for " + eFuelType.Octan96 + " fuel\n" +
                 "Please enter 3 for " + eFuelType.Octan98 + " fuel\n" +
                 "Please enter 4 for " + eFuelType.Soler + " fuel"] = i_FuelType => insertFuelType(i_FuelType),
                ["Please enter how much fuel you currently have"] = i_FuelQuantity => insertCurrentFuelQuantity(i_FuelQuantity),
                ["Please enter how much fuel to fill"] = i_FuelQuantity => insertFuelQuantity(i_FuelQuantity)
            };


        }

        private eOperationStatus insertLicenseNumber(string i_LicenseNumber)
        {
            m_LicenseNumber = m_GarageManager.GetParsedLicenseNumber(i_LicenseNumber);
            if (m_GarageManager.CheckIfLicenseNumberExists(m_LicenseNumber))
            {
                IRegularVehicle regularVehicle = m_GarageManager.GetVehiclesByLicenseNumber(m_LicenseNumber) as IRegularVehicle;
                if(regularVehicle == null)
                {
                    throw new ArgumentException($"Vehicle {m_LicenseNumber} operation is not supported for this vehicle ! Please try again");
                }
                m_Vehicle = regularVehicle;
            }

            return eOperationStatus.CanProceed;
        }

        private eOperationStatus insertFuelType(string i_FuelType)
        { 
            if (!Enum.TryParse(i_FuelType, out m_FuelType) || !Enum.IsDefined(typeof(eFuelType), m_FuelType))
            {
                throw new ArgumentException("The fuel type you entered doesn't exists! Please try again");
            }

            if (m_FuelType != m_Vehicle.FuelType)
            {
                throw new ArgumentException("The fuel you entered is not suitable for this vehicle type! Please try again");
            }

            return eOperationStatus.CanProceed;
        }

        private eOperationStatus insertCurrentFuelQuantity(string i_FuelQuantity)
        {
            float fuelQuantityToInsert;
            if (!float.TryParse(i_FuelQuantity, out fuelQuantityToInsert))
            {
                throw new ArgumentException("The number you entered is not legal! Please try again");
            }
            if(fuelQuantityToInsert < 0 || fuelQuantityToInsert > m_Vehicle.MaxAmountOfFuelInLiters)
            {
                throw new ValueOutOfRangeException($"The fuel must be between {0} and {m_Vehicle.MaxAmountOfFuelInLiters}! Please try again");
            }

            m_Vehicle.CurrentAmountOfFuelInLiters = fuelQuantityToInsert;
            return eOperationStatus.CanProceed;
        }

        private eOperationStatus insertFuelQuantity(string i_FuelQuantity)
        {
            float fuelQuantityToInsert;
            if (!float.TryParse(i_FuelQuantity, out fuelQuantityToInsert))
            {
                throw new ArgumentException("The number you entered is not legal! Please try again");
            }
            m_Vehicle.Refuel(fuelQuantityToInsert, m_FuelType);

            m_OperationResult = $"Vehicle {m_LicenseNumber} fueled successfully!";
            return eOperationStatus.Completed;
        }

    }
}
