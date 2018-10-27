using System.Collections.Generic;
using GarageLogic.Models;

namespace GarageLogic.Services
{
    public interface IGarageService
    {
        IEnumerable<Operation> GetGarageOperations();
    }
}
