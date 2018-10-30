using System;
using System.Collections.Generic;
using System.Linq;

namespace GarageLogic.Models
{
    public enum eColor
    {
        Gray = 1,
        Blue,
        White,
        Black
    }

    public abstract class Car : Vehicle
    {
        public const int k_MaxAirPressureByManufacturer = 32;

        public const int k_NumberOfWheels = 4;
        protected Car()
        {
            //Color = GetRandomColor();
            //DoorsNumber = GetRandomDoorsNumber();

            Wheels = new List<Wheel>();
            //{
            //    new Wheel("Wheels", k_MaxAirPressureByManufacturer),
            //    new Wheel("Wheels", k_MaxAirPressureByManufacturer),
            //    new Wheel("Wheels", k_MaxAirPressureByManufacturer),
            //    new Wheel("Wheels", k_MaxAirPressureByManufacturer)
            //};
        }

        public eColor Color { get; set; }

        public int DoorsNumber { get; set; }

        private eColor GetRandomColor()
        {
            Array values = Enum.GetValues(typeof(eColor));
            Random random = new Random();
            return (eColor)values.GetValue(random.Next(values.Length));
        }
        private int GetRandomDoorsNumber()
        {
            Random random = new Random();
            return random.Next(2, 5);
        }

    }
}
