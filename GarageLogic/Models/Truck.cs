namespace GarageLogic.Models
{
    class Truck : Car
    {
        public bool IsCarryingHazardousMaterials { get; set; }
        public float MaxCarryingWeightAllowed { get; set; }

    }
}
