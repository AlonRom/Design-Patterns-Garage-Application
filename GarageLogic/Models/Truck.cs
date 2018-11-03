using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GarageLogic.Exceptions;
using GarageLogic.Extensions;
using GarageLogic.Interfaces;

namespace GarageLogic.Models
{
    public class Truck : Vehicle, IRegularVehicle
    {
        public const int k_MaxAirPressureByManufacturer = 28;

        public const int k_NumberOfWheels = 12;
        public Truck()
        {
            FuelType = eFuelType.Octan96;
            MaxAmountOfFuelInLiters = 115;
            Wheels = new List<Wheel>();
        }

        [Display(Name = "Is carrying hazardous materials")]
        public bool IsCarryingHazardousMaterials { get; set; }

        [Display(Name = "Max carrying weight allowed")]
        public float MaxCarryingWeightAllowed { get; set; }

        [Display(Name = "Fuel type")]
        public eFuelType FuelType { get; set; }

        [Display(Name = "Current amount of fuel in liters")]
        public float CurrentAmountOfFuelInLiters { get; set; }

        [Display(Name = "Max amount of fuel in liters")]
        public float MaxAmountOfFuelInLiters { get; set; }

        public void Refuel(float i_LitersToAdd, eFuelType i_FuelType)
        {
            if (i_LitersToAdd < 0 || CurrentAmountOfFuelInLiters + i_LitersToAdd > MaxAmountOfFuelInLiters)
            {
                throw new ValueOutOfRangeException(0, MaxAmountOfFuelInLiters, string.Format("The fuel must be between {0} and {1}! Please try again", 0, MaxAmountOfFuelInLiters));
            }
            CurrentAmountOfFuelInLiters += i_LitersToAdd;
        }

        public override string ToString()
        {
            return this.ToString(GetType());
        }
    }
}
