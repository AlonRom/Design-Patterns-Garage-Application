using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GarageLogic.Extensions;

namespace GarageLogic.Models
{
    public abstract class Vehicle
    {
        [Display(Name = "License Number")]
        public int LicenseNumber { get; set; }

        [Display(Name = "Model Name")]
        public string ModelName { get; set; }

        [Display(Name = "Wheels Details")]
        public List<Wheel> Wheels { get; set; }

        public override string ToString()
        {
            return this.ToString(GetType());
        }
    }
}
