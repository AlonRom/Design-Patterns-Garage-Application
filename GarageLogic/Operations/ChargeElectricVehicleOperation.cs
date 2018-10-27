using GarageLogic.Interfaces;
using GarageLogic.Models;

namespace GarageLogic.Operations
{
    public class ChargeElectricVehicleOperation : Operation
    {
        public ChargeElectricVehicleOperation(IGarageManager i_GarageManager)
        {
            Index = 6;
            Details = "Charge an electric vehicle";
        }
    }
}
