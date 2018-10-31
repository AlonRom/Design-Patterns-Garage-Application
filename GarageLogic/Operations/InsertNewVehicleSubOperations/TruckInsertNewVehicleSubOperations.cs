using System;
using GarageLogic.Interfaces;
using GarageLogic.Models;

namespace GarageLogic.Operations.InsertNewVehicleSubOperations
{
    public class TruckInsertNewVehicleSubOperations : BaseInsertNewVehicleSubOperations
    {
        private new Truck Vehicle { get; set; }

        private bool m_IsCarryingHazardousMaterials;
        public TruckInsertNewVehicleSubOperations(IGarageManager i_GarageManager)
            : base(i_GarageManager)
        {
            m_GarageManager = i_GarageManager;
            AddWheelsInstructions(Truck.k_NumberOfWheels, Truck.k_MaxAirPressureByManufacturer);
            addCarryingHazardousMaterialsInstruction();
        }

        private void addCarryingHazardousMaterialsInstruction()
        {
            SubMenuInstructions.Add("Please enter Yes or No if the truck is carrying hazardous materials",insertIfCarryingHazardousMaterials);
        }

        private eOperationStatus insertIfCarryingHazardousMaterials(string i_IsCarryingHazardousMaterials)
        {
            string userInputLowerCase = i_IsCarryingHazardousMaterials.ToLower();
            if (userInputLowerCase == "yes")
            {
                m_IsCarryingHazardousMaterials = true;
            }
            else if(userInputLowerCase == "no")
            {
                m_IsCarryingHazardousMaterials = false;
            }
            else
            {
                throw new ArgumentException("The value you entered is not legal! Please try again");
            }

            InsertNewVehicle();
            return eOperationStatus.Completed;
        }

        protected override void InsertNewVehicle()
        {
            Vehicle = (Truck)base.Vehicle;
            Vehicle.IsCarryingHazardousMaterials = m_IsCarryingHazardousMaterials;
            m_GarageManager.InsertNewVehicle(m_LicenseNumber, m_OwnerName, m_OwnerPhone, Vehicle);
        }
    }
}
