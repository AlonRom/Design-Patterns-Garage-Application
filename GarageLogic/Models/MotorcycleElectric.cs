using System.ComponentModel.DataAnnotations;
using GarageLogic.Exceptions;
using GarageLogic.Extensions;
using GarageLogic.Interfaces;

namespace GarageLogic.Models
{
    class MotorcycleElectric : Motorcycle, IElectricVehicle
    {
        public MotorcycleElectric()
        {
            MaxBatteryTimeInHours = (float)1.8;
        }

        [Display(Name = "Remaining battery time in hours")]
        public float RemainingBatteryTimeInHours { get; set; }

        [Display(Name = "Max battery time in hours")]
        public float MaxBatteryTimeInHours { get; set; }

        public void ChargeBattery(float i_HoursToAddToBattery)
        {
            if (i_HoursToAddToBattery < 0 || RemainingBatteryTimeInHours + i_HoursToAddToBattery > MaxBatteryTimeInHours)
            { 
                throw new ValueOutOfRangeException(0, MaxBatteryTimeInHours, string.Format("The battery time must be between {0} and {1}! Please try again", 0, MaxBatteryTimeInHours));
            }
            RemainingBatteryTimeInHours += i_HoursToAddToBattery;
        }

        public override string ToString()
        {
            return this.ToString(GetType());
        }
    }
}
