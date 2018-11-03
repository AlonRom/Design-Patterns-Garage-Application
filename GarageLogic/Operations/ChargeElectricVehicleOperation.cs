using System;
using System.Collections.Generic;
using GarageLogic.Exceptions;
using GarageLogic.Interfaces;

namespace GarageLogic.Operations
{
    public class ChargeElectricVehicleOperation : Operation
    {
        private int m_LicenseNumber;
        private IElectricVehicle m_Vehicle;
        public ChargeElectricVehicleOperation(IGarageManager i_GarageManager)
        {
            m_GarageManager = i_GarageManager;
            Index = 6;
            Details = "Charge an electric vehicle";

            Instructions = new Dictionary<string, Func<string, eOperationStatus>>
            {
                ["Please enter a vehicle license number"] = i_LicenseNumber => insertLicenseNumber(i_LicenseNumber),
                ["Please enter how much battery time in hours you currently have"] = i_CurrentBatteryTimeLeftInHours => insertCurrentBatteryTimeLeftInHours(i_CurrentBatteryTimeLeftInHours),
                ["Please enter how much battery time to charge"] = i_BatteryTimeInHoursToCharge => insertBatteryTimeInHoursToCharge(i_BatteryTimeInHoursToCharge)
            };
        }

        private eOperationStatus insertLicenseNumber(string i_LicenseNumber)
        {
            m_LicenseNumber = m_GarageManager.GetParsedLicenseNumber(i_LicenseNumber);
            if (m_GarageManager.CheckIfLicenseNumberExists(m_LicenseNumber))
            {
                IElectricVehicle electricVehicle = m_GarageManager.GetVehiclesByLicenseNumber(m_LicenseNumber) as IElectricVehicle;
                if (electricVehicle == null)
                {
                    throw new ArgumentException($"This operation is not supported for vehicle {m_LicenseNumber} ! Please try again");
                }
                m_Vehicle = electricVehicle;
            }

            return eOperationStatus.CanProceed;
        }

        private eOperationStatus insertCurrentBatteryTimeLeftInHours(string i_CurrentBatteryTimeLeftInHours)
        {
            float currentBatteryTimeLeftInHours;
            if (!float.TryParse(i_CurrentBatteryTimeLeftInHours, out currentBatteryTimeLeftInHours))
            {
                throw new FormatException("The number you entered is not legal! Please try again");
            }

            if (currentBatteryTimeLeftInHours < 0 || currentBatteryTimeLeftInHours > m_Vehicle.MaxBatteryTimeInHours)
            {
                throw new ValueOutOfRangeException(0, m_Vehicle.MaxBatteryTimeInHours, string.Format("The battery time must be between {0} and {1}! Please try again", 0, m_Vehicle.MaxBatteryTimeInHours));
            }

            m_Vehicle.RemainingBatteryTimeInHours = currentBatteryTimeLeftInHours;
            return eOperationStatus.CanProceed;
        }

        private eOperationStatus insertBatteryTimeInHoursToCharge(string i_BatteryTimeInHoursToCharge)
        {
            float batteryTimeInHoursToCharge;
            if (!float.TryParse(i_BatteryTimeInHoursToCharge, out batteryTimeInHoursToCharge))
            {
                throw new FormatException("The number you entered is not legal! Please try again");
            }
            if (batteryTimeInHoursToCharge < 0 || batteryTimeInHoursToCharge > m_Vehicle.MaxBatteryTimeInHours)
            {
                throw new ValueOutOfRangeException(0, m_Vehicle.MaxBatteryTimeInHours, string.Format("The battery time must be between {0} and {1}! Please try again", 0, m_Vehicle.MaxBatteryTimeInHours));
            }

            m_Vehicle.ChargeBattery(batteryTimeInHoursToCharge);

            m_OperationResult = $"Vehicle {m_LicenseNumber} charged successfully!";
            return eOperationStatus.Completed;
        }

    }
}
