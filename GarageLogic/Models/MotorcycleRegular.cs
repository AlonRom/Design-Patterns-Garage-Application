using System;
using GarageLogic.Interfaces;

namespace GarageLogic.Models
{
    class MotorcycleRegular : Motorcycle, IRegularVehicle
    {
        public MotorcycleRegular()
        {
            FuelType = eFuelType.Octan96;
            MaxAmountOfFuelInLiters = 6;
        }

        public eFuelType FuelType { get; set; }

        public float CurrentAmountOfFuelInLiters { get; set; }

        public float MaxAmountOfFuelInLiters { get; set; }

        public void Refuel(float i_LitersToAdd, eFuelType i_FuelType)
        {
            throw new NotImplementedException();
        }
    }
}
