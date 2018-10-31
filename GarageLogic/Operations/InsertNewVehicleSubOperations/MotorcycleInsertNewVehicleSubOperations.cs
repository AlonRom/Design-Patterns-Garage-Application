using System;
using GarageLogic.Interfaces;
using GarageLogic.Models;

namespace GarageLogic.Operations.InsertNewVehicleSubOperations
{
    public class MotorcycleInsertNewVehicleSubOperations : BaseInsertNewVehicleSubOperations
    {
        private eLicenseType m_LicenseType;
        private int m_CarEngineVolume;

        private new Motorcycle Vehicle { get; set; }

        protected MotorcycleInsertNewVehicleSubOperations(IGarageManager i_GarageManager)
            : base(i_GarageManager)
        {
            m_GarageManager = i_GarageManager;
            addLicenseTypeInstruction();
            AddWheelsInstructions(Motorcycle.k_NumberOfWheels, Motorcycle.k_MaxAirPressureByManufacturer);
            addEngineVolumeIntruction();
        }

        private void addLicenseTypeInstruction()
        {
            SubMenuInstructions.Add(
                "Please enter 1 for " + eLicenseType.A + " license\n" +
                "Please enter 2 for " + eLicenseType.A1 + " license\n" +
                "Please enter 3 for " + eLicenseType.B1 + " license\n" +
                "Please enter 4 for " + eLicenseType.B2 + " license",
                insertLicenseType);
        }

        private void addEngineVolumeIntruction()
        {
            SubMenuInstructions.Add("Please enter engine volume in cc", insertCarEngineVolume);
        }


        private eOperationStatus insertLicenseType(string i_LicenseType)
        {
            if (Enum.TryParse(i_LicenseType, out m_LicenseType) && Enum.IsDefined(typeof(eLicenseType), m_LicenseType))
            {
                return eOperationStatus.CanProceed;
            }

            throw new ArgumentException("The license type you entered doesn't exists! Please try again");
        }


        private eOperationStatus insertCarEngineVolume(string i_CarEngineVolume)
        {
            int engineVolumeToInsert;
            if (!int.TryParse(i_CarEngineVolume, out engineVolumeToInsert))
            {
                throw new ArgumentException("The number you entered is not legal! Please try again");
            }
            m_CarEngineVolume = engineVolumeToInsert;

            InsertNewVehicle();
            return eOperationStatus.Completed;
        }

        protected override void InsertNewVehicle()
        {
            Vehicle = (Motorcycle)base.Vehicle;
            Vehicle.EngineVolumeCc = m_CarEngineVolume;
            Vehicle.LicenseType = m_LicenseType;

            m_GarageManager.InsertNewVehicle(m_LicenseNumber, m_OwnerName, m_OwnerPhone, Vehicle);
        }
    }
}
