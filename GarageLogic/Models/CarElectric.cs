using System;
using GarageLogic.Interfaces;

namespace GarageLogic.Models
{
    class CarElectric : Car, IElectricVehicle
    {
        public CarElectric()
        {
            MaxBatteryTimeInHours = (float)3.2;
        }
        public float RemainingBatteryTimeInHours { get; set; }

        public float MaxBatteryTimeInHours { get; set; }

        public void ChargeBattery(float i_HoursToAddToBattery)
        {
            throw new NotImplementedException();
        }
    }
}
