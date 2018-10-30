using GarageLogic.Interfaces;

namespace GarageLogic.Operations.InsertNewVehicleSubOperations
{
    class CarElectricInsertNewVehicleSubOperations : CarInsertNewVehicleSubOperations
    {
        public CarElectricInsertNewVehicleSubOperations(IGarageManager i_GarageManager)
            : base(i_GarageManager)
        {
        }
    }
}
