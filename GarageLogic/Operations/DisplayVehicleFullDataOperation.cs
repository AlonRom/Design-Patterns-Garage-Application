using GarageLogic.Interfaces;
using GarageLogic.Models;

namespace GarageLogic.Operations
{
    public class DisplayVehicleFullDataOperation : Operation
    {
        public DisplayVehicleFullDataOperation(IGarageManager i_GarageManager)
        {
            Index = 7;
            Details = "View full vehicle data";
        }
    }
}
