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
            throw new System.NotImplementedException();
        }
    }
}
