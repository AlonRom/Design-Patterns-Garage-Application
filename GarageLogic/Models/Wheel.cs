namespace GarageLogic.Models
{
    public class Wheel  
    {
        public Wheel(string i_ManufacturerName, float i_CurrentWheelPressureToInsert, float i_MaxAirPressure)
        {
            ManufacturerName = i_ManufacturerName;
            CurrentAirPressure = i_CurrentWheelPressureToInsert;
            MaxAirPressureByManufacturer = i_MaxAirPressure;
        }
        protected string ManufacturerName { get; set; }

        public float CurrentAirPressure { get; set; }

        public float MaxAirPressureByManufacturer { get; set; }

        public void InflateWheel(float i_AirPressureToAdd)
        {
            
        }

    }
}