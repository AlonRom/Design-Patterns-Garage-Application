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
        public eVehicleState VehicleState { get; set; }

        public string OwnerName { get; set; }

        public string OwnerPhone { get; set; }

    }
}
