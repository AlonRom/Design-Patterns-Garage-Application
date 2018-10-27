using System;
using GarageLogic.Interfaces;

namespace GarageLogic.Models
{
    class ElectricCar : Car, IElectricVehicle
    {
        public float RemainingBatteryTimeInHours { get; set; }

        public float MaxBatteryTimeInHours { get; set; }

        public void ChargeBattery(float i_HoursToAddToBattery)
        {
            throw new NotImplementedException();
        }
    }
}
