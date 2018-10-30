using System;
using GarageLogic.Interfaces;

namespace GarageLogic.Models
{
    class MotorcycleElectric : Motorcycle, IElectricVehicle
    {
        public MotorcycleElectric()
        {
            MaxBatteryTimeInHours = (float)1.8;
        }
        public float RemainingBatteryTimeInHours { get; set; }

        public float MaxBatteryTimeInHours { get; set; }

        public void ChargeBattery(float i_HoursToAddToBattery)
        {
            throw new NotImplementedException();
        }
    }
}
