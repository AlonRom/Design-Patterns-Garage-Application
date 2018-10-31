using System;
using System.Collections.Generic;

namespace GarageLogic.Models
{
    public enum eLicenseType
    {
        A = 1,
        A1 = 2,
        B1 = 3,
        B2 = 4
    }

    public abstract class Motorcycle : Vehicle
    {
        public const int k_MaxAirPressureByManufacturer = 30;
        public const int k_NumberOfWheels = 2;
        protected Motorcycle()
        {
            Wheels = new List<Wheel>();
        }

        public eLicenseType LicenseType { get; set; }

        public int EngineVolumeCc { get; set; }

        //private eLicenseType GetRandomLicenseType()
        //{
        //    Array values = Enum.GetValues(typeof(eLicenseType));
        //    Random random = new Random();
        //    return (eLicenseType)values.GetValue(random.Next(values.Length));
        //}
        //private int GetRandomVolumCc()
        //{
        //    Random random = new Random();
        //    return random.Next(50, 300);
        //}
    }
}
