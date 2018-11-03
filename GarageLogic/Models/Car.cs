using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GarageLogic.Extensions;

namespace GarageLogic.Models
{
    public enum eColor
    {
        Gray = 1,
        Blue = 2,
        White = 3,
        Black = 4
    }

    public abstract class Car : Vehicle
    {
        public const int k_MaxAirPressureByManufacturer = 32;

        public const int k_NumberOfWheels = 4;
        protected Car()
        {
            Wheels = new List<Wheel>();
        }

        [Display(Name = "Color")]
        public eColor Color { get; set; }

        [Display(Name = "Doors Number")]
        public int DoorsNumber { get; set; }

        public override string ToString()
        {
            return this.ToString(GetType());
        }
    }
}
