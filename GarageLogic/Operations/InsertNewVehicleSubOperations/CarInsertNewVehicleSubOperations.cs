using System;
using GarageLogic.Interfaces;
using GarageLogic.Models;

namespace GarageLogic.Operations.InsertNewVehicleSubOperations
{
    public class CarInsertNewVehicleSubOperations : BaseInsertNewVehicleSubOperations
    {
        private eColor m_CarColor;
        private int m_CarDoorsNumber;

        private new Car Vehicle { get; set; }

        protected CarInsertNewVehicleSubOperations(IGarageManager i_GarageManager)
            : base(i_GarageManager)
        {
            m_GarageManager = i_GarageManager;
            addColorInstruction();
            AddWheelsInstructions(Car.k_NumberOfWheels, Car.k_MaxAirPressureByManufacturer);
            addDoorsNumberInstruction();
        }

        private void addColorInstruction()
        {
            SubMenuInstructions.Add(
                "Please enter 1 for" + eColor.Gray + " color\n" +
                "Please enter 2 for" + eColor.Blue + " color\n" + 
                "Please enter 3 for" + eColor.White + " color\n" +
                "Please enter 4 for" + eColor.Black + " color" ,
                insertCarColor);

        }

        private void addDoorsNumberInstruction()
        {
            SubMenuInstructions.Add("Please enter car number of doors (2 - 5)", insertCarDoorsNumber);
        }

        private eOperationStatus insertCarColor(string i_CarColor)
        {
            if(Enum.TryParse(i_CarColor, out m_CarColor) && Enum.IsDefined(typeof(eColor), m_CarColor))
            {
                return eOperationStatus.CanProceed;
            }

            throw new FormatException("The color you entered doesn't exists! Please try again");
        }

        private eOperationStatus insertCarDoorsNumber(string i_CarDoorsNumber)
        {
            int doorsNumberToInsert;
            if (!int.TryParse(i_CarDoorsNumber, out doorsNumberToInsert))
            {
                throw new FormatException("The number you entered is not legal! Please try again");
            }
            if (doorsNumberToInsert < 2 || doorsNumberToInsert > 5)
            {
                throw new ArgumentException("The doors number you entered doesn't exists! Please try again");
            }
            m_CarDoorsNumber = doorsNumberToInsert;

            InsertNewVehicle();
            return eOperationStatus.Completed;
        }

        protected override void InsertNewVehicle()
        {
            Vehicle = (Car)base.Vehicle;
            Vehicle.Color = m_CarColor;
            Vehicle.DoorsNumber = m_CarDoorsNumber;
            base.InsertNewVehicle();
        }
    }
}
