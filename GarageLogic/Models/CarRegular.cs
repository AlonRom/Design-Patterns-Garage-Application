using GarageLogic.Exceptions;
using GarageLogic.Interfaces;

namespace GarageLogic.Models
{
    class CarRegular : Car, IRegularVehicle
    {
        public CarRegular()
        {
            FuelType = eFuelType.Octan98;
            MaxAmountOfFuelInLiters = 45;
        }
        public eFuelType FuelType { get; set; }

        public float CurrentAmountOfFuelInLiters { get; set; }

        public float MaxAmountOfFuelInLiters { get; set; }

        public void Refuel(float i_LitersToAdd, eFuelType i_FuelType)
        {
            if (i_LitersToAdd < 0 || CurrentAmountOfFuelInLiters + i_LitersToAdd > MaxAmountOfFuelInLiters)
            {
                throw new ValueOutOfRangeException($"The fuel must be between {0} and {MaxAmountOfFuelInLiters}! Please try again");
            }
            CurrentAmountOfFuelInLiters += i_LitersToAdd;
        }
    }
}
