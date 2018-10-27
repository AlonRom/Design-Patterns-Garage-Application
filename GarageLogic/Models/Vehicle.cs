using System.Collections.Generic;

namespace GarageLogic.Models
{
    public abstract class Vehicle
    {
        public string ModelName { get; set; }

        public string LicenseNumber { get; set; }

        public float EnergyLeftPercentage { get; set; }

        public List<Wheel> Wheels { get; set; }

    }
}
