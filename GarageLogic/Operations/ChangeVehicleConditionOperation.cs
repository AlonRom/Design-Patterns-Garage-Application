using GarageLogic.Interfaces;
using GarageLogic.Models;

namespace GarageLogic.Operations
{
    public class ChangeVehicleConditionOperation : Operation
    {
        public ChangeVehicleConditionOperation(IGarageManager i_GarageManager)
        {
            Index = 3;
            Details = "Change the condition of a vehicle in the garage";
        }
    }
}
