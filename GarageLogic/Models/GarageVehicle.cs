using System.ComponentModel.DataAnnotations;
using GarageLogic.Extensions;

namespace GarageLogic.Models
{
    public enum eVehicleState
    {
        DuringFix = 1,
        Fixed = 2,
        Paid = 3 
    }

    public class GarageVehicle
    {
        public Vehicle Vehicle { get; set; }    

        [Display(Name = "Vehicle State")]
        public eVehicleState VehicleState { get; set; }

        [Display(Name = "Owner Name")]
        public string OwnerName { get; set; }

        [Display(Name = "Owner Phone")]
        public string OwnerPhone { get; set; }

        public override string ToString()
        {
            return this.ToString(GetType()) + Vehicle.ToString(Vehicle.GetType());
        }
    }
}
