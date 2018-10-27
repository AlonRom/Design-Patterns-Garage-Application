using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            GarageManagerUi garageManagerUi = new GarageManagerUi();
            garageManagerUi.Run();
            Console.ReadLine();
        }
    }
}
