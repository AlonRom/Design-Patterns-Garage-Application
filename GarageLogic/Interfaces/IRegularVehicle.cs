namespace GarageLogic.Interfaces
{
    enum eFuelType
    {
        Octan98 = 1,
        Octan96 = 2,
        Octan95 = 3,
        Soler = 4
    }
    interface IRegularVehicle
    {
        eFuelType FuelType { get; set; }
        float CurrentAmountOfFuelInLiters { get; set; }
        float MaxAmountOfFuelInLiters { get; set; }
        void Refuel(float i_LitersToAdd, eFuelType i_FuelType);

    }
}
