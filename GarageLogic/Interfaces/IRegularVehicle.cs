namespace GarageLogic.Interfaces
{
    enum eFuelType
    {
        Octan98,
        Octan96,
        Octan95,
        Soler
    }
    interface IRegularVehicle
    {
        eFuelType FuelType { get; set; }
        float CurrentAmountOfFuelInLiters { get; set; }
        float MaxAmountOfFuelInLiters { get; set; }
        void Refuel(float i_LitersToAdd, eFuelType i_FuelType);

    }
}
