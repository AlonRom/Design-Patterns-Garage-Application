using GarageLogic.Interfaces;

namespace GarageLogic.Operations
{
    public class ChargeElectricVehicleOperation : Operation
    {
        public ChargeElectricVehicleOperation(IGarageManager i_GarageManager)
        {
            m_GarageManager = i_GarageManager;
            Index = 6;
            Details = "Charge an electric vehicle";
        }
    }
}
