namespace GarageLogic.Models
{
    public abstract class Wheel  
    {
        public string ManufacturerName { get; set; }

        public float CurrentAirPressure { get; set; }

        public float MaxAirPressureByManufacturer { get; set; }

        private void inflateWheel(float i_AirPressureToAdd)
        {
            
        }

    }
}