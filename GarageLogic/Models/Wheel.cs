using GarageLogic.Exceptions;

namespace GarageLogic.Models
{
    public class Wheel  
    {
        private string ManufacturerName { get; set; }

        private float m_CurrentAirPressure;

        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
            set
            {
                if (value < 0 || value > MaxAirPressureByManufacturer)
                {
                    throw new ValueOutOfRangeException($"The wheel pressure must be between {0} and {MaxAirPressureByManufacturer}");
                }
                m_CurrentAirPressure = value;
            }
        }

        public float MaxAirPressureByManufacturer { get; }
        public Wheel(string i_ManufacturerName, float i_CurrentWheelPressureToInsert, float i_MaxAirPressure)
        {
            ManufacturerName = i_ManufacturerName;
            MaxAirPressureByManufacturer = i_MaxAirPressure;
            CurrentAirPressure = i_CurrentWheelPressureToInsert;
        }

        public void InflateWheel(float i_AirPressureToAdd)
        {
            m_CurrentAirPressure += i_AirPressureToAdd;
        }

    }
}