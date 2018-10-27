using System;
using GarageLogic.Interfaces;

namespace GarageLogic.Models
{
    class RegularMotorcycle : Motorcycle, IRegularVehicle
    {
        public eFuelType FuelType { get; set; }

        public float CurrentAmountOfFuelInLiters { get; set; }

        public float MaxAmountOfFuelInLiters { get; set; }

        public void Refuel(float i_LitersToAdd, eFuelType i_FuelType)
        {
            throw new NotImplementedException();
        }
    }
}
