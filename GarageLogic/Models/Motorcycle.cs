using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GarageLogic.Extensions;

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

        [Display(Name = "License type")]
        public eLicenseType LicenseType { get; set; }

        [Display(Name = "Engine volume CC")]
        public int EngineVolumeCc { get; set; }

        public override string ToString()
        {
            return this.ToString(GetType());
        }
    }
}
