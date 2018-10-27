using System.Collections.Generic;
using GarageLogic.Models;

namespace GarageLogic.Interfaces
{
    public interface IGarageManager
    {
        Dictionary<int, GarageVehicle> GetGarageVehicles();
        void SetVehicleState(int i_LicenseNumber, eVehicleState i_VehicleState);
        void InsertNewVehicle(int i_LicenseNumber, string i_OwnerName, string i_OwnerPhone);
        IEnumerable<int> GetAllVehiclesLicenseNumber();
        IEnumerable<int> GetVehiclesLicenseNumberByState(eVehicleState i_VehicleState);
        IEnumerable<Operation> GetOperations();

    }
}
