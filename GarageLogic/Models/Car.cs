namespace GarageLogic.Models
{
    enum eColor
    {
        Gray,
        Blue,
        White,
        Black
    }

    class Car
    {
        public eColor Color { get; set; }
        public int DoorsNumber { get; set; }

    }
}
