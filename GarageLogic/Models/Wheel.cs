using System.ComponentModel.DataAnnotations;
using GarageLogic.Exceptions;
using GarageLogic.Extensions;

namespace GarageLogic.Models
{
    public class Wheel  
    {
        [Display(Name = "Manufacturer name")]
        public string ManufacturerName { get; set; }

        private float m_CurrentAirPressure;

        [Display(Name = "Current air pressure")]
        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
            set
            {
                if (value < 0 || value > MaxAirPressureByManufacturer)
                {
                    throw new ValueOutOfRangeException(0, MaxAirPressureByManufacturer, string.Format("The wheel pressure must be between {0} and {1}! Please try again", 0, MaxAirPressureByManufacturer));
                }
                m_CurrentAirPressure = value;
            }
        }

        [Display(Name = "Max air pressure by manufacturer")]
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
        public override string ToString()
        {
            return this.ToString(GetType());
        }
    }
}