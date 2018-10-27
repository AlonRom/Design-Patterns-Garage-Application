using GarageLogic.Interfaces;
using GarageLogic.Models;

namespace GarageLogic.Operations
{
    public class FuelVehicleOperation : Operation
    {
        public FuelVehicleOperation(IGarageManager i_GarageManager)
        {
            Index = 5;
            Details = "Fuel a vehicle driven by fuel";
        }
    }
}
