using System;
using GarageLogic.Interfaces;
using GarageLogic.Models;

namespace GarageLogic.Operations.InsertNewVehicleSubOperations
{
    public class TruckInsertNewVehicleSubOperations : BaseInsertNewVehicleSubOperations
    {
        private new Truck Vehicle { get; set; }

        private bool m_IsCarryingHazardousMaterials;
        private float m_MaximumCarryingWeightAllowedToInsert;

        public TruckInsertNewVehicleSubOperations(IGarageManager i_GarageManager)
            : base(i_GarageManager)
        {
            m_GarageManager = i_GarageManager;
            AddWheelsInstructions(Truck.k_NumberOfWheels, Truck.k_MaxAirPressureByManufacturer);
            addCarryingHazardousMaterialsInstruction();
        }

        private void addCarryingHazardousMaterialsInstruction()
        {
            SubMenuInstructions.Add("Please enter maximum carrying weight is allowed", insertMaximumCarryingWeightAllowed);
            SubMenuInstructions.Add("Please enter Yes or No if the truck is carrying hazardous materials",insertIfCarryingHazardousMaterials);
        }

        private eOperationStatus insertMaximumCarryingWeightAllowed(string i_InsertMaximumCarryingWeightAllowed)
        {
            if (!float.TryParse(i_InsertMaximumCarryingWeightAllowed, out m_MaximumCarryingWeightAllowedToInsert))
            {
                throw new FormatException("The number you entered is not legal! Please try again");
            }

            return eOperationStatus.CanProceed;
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
            Vehicle.MaxCarryingWeightAllowed = m_MaximumCarryingWeightAllowedToInsert;
            Vehicle.IsCarryingHazardousMaterials = m_IsCarryingHazardousMaterials;
            base.InsertNewVehicle();
        }
    }
}
