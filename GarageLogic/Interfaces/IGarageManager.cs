using System.Collections.Generic;
using GarageLogic.Models;
using GarageLogic.Operations;
using GarageLogic.Operations.InsertNewVehicleSubOperations;

namespace GarageLogic.Interfaces
{
    public interface IGarageManager
    {
        Dictionary<int, GarageVehicle> GetGarageVehicles();
        void SetVehicleState(int i_LicenseNumber, eVehicleState i_VehicleState);
        void InsertNewVehicle(int i_LicenseNumber, string i_OwnerName, string i_OwnerPhone, Vehicle i_Vehicle);
        IEnumerable<int> GetAllVehiclesLicenseNumber();
        IEnumerable<int> GetVehiclesLicenseNumberByState(eVehicleState i_VehicleState);
        Vehicle GetVehiclesByLicenseNumber(int i_LicenseNumber);
        int GetParsedLicenseNumber(string i_LicenseNumber);
        bool CheckIfLicenseNumberExists(int i_LicenseNumber);
        Vehicle GetVehicleType(string i_VehicleType);
        IEnumerable<Operation> GetOperations();
        IEnumerable<BaseInsertNewVehicleSubOperations> GetSubOperation(string i_VehicleTypeName);

    }
}
