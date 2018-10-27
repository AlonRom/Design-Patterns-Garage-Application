namespace GarageLogic.Interfaces
{
    interface IElectricVehicle
    {
        float RemainingBatteryTimeInHours { get; set; }
        float MaxBatteryTimeInHours { get; set; }
        void ChargeBattery(float i_HoursToAddToBattery);

    }
}
