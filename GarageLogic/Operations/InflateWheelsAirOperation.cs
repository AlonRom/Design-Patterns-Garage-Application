using GarageLogic.Interfaces;
using GarageLogic.Models;

namespace GarageLogic.Operations
{
    public class InflateWheelsAirOperation : Operation
    {
        public InflateWheelsAirOperation(IGarageManager i_GarageManager)
        {
            Index = 4;
            Details = "Inflate the air in the wheels of a vehicle to a maximum";
        }
    }
}
