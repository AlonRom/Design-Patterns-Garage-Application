using GarageLogic.Interfaces;

namespace GarageLogic.Operations
{
    public class DisplayVehicleFullDataOperation : Operation
    {
        public DisplayVehicleFullDataOperation(IGarageManager i_GarageManager)
        {
            m_GarageManager = i_GarageManager;
            Index = 7;
            Details = "View full vehicle data";
        }
    }
}
