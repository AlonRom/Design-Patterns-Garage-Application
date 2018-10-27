namespace GarageLogic.Models
{
    enum eLicenseType
    {
        A,
        A1,
        B1,
        B2
    }

    class Motorcycle : Vehicle
    {
        public eLicenseType LicenseType { get; set; }

        public int EngineVolumeCc { get; set; }
    }
}
