using System.Collections.Generic;

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

        public eColor Color { get; set; }

        public int DoorsNumber { get; set; }
    }
}
