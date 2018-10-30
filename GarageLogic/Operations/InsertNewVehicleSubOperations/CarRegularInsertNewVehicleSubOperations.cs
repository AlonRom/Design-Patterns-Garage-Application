using GarageLogic.Interfaces;

namespace GarageLogic.Operations.InsertNewVehicleSubOperations
{
    class CarRegularInsertNewVehicleSubOperations : CarInsertNewVehicleSubOperations
    {
        public CarRegularInsertNewVehicleSubOperations(IGarageManager i_GarageManager)
            : base(i_GarageManager)
        {
        }
    }
}
