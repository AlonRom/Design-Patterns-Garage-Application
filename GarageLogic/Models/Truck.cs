using System.Collections.Generic;
using GarageLogic.Interfaces;

namespace GarageLogic.Models
{
    class Truck : Vehicle, IRegularVehicle
    {
        public const int k_MaxAirPressureByManufacturer = 28;

        public const int k_NumberOfWheels = 12;
        public Truck()
        {
            FuelType = eFuelType.Octan96;
            MaxAmountOfFuelInLiters = 115;
            Wheels = new List<Wheel>();
                         //{
                         //    new Wheel("Wheels", k_MaxAirPressureByManufacturer),
                         //    new Wheel("Wheels", k_MaxAirPressureByManufacturer),
                         //    new Wheel("Wheels", k_MaxAirPressureByManufacturer),
                         //    new Wheel("Wheels", k_MaxAirPressureByManufacturer),
                         //    new Wheel("Wheels", k_MaxAirPressureByManufacturer),
                         //    new Wheel("Wheels", k_MaxAirPressureByManufacturer),
                         //    new Wheel("Wheels", k_MaxAirPressureByManufacturer),
                         //    new Wheel("Wheels", k_MaxAirPressureByManufacturer),
                         //    new Wheel("Wheels", k_MaxAirPressureByManufacturer),
                         //    new Wheel("Wheels", k_MaxAirPressureByManufacturer),
                         //    new Wheel("Wheels", k_MaxAirPressureByManufacturer),
                         //    new Wheel("Wheels", k_MaxAirPressureByManufacturer)
                         //};

        }
        public bool IsCarryingHazardousMaterials { get; set; }
        public float MaxCarryingWeightAllowed { get; set; }

        public eFuelType FuelType { get; set; }

        public float CurrentAmountOfFuelInLiters { get; set; }

        public float MaxAmountOfFuelInLiters { get; set; }

        public void Refuel(float i_LitersToAdd, eFuelType i_FuelType)
        {
            throw new System.NotImplementedException();
        }
    }
}
