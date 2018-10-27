using System;
using System.Collections.Generic;
using System.Linq;
using GarageLogic.Models;

namespace GarageLogic.Services
{
    public class GarageService : IGarageService
    {
        public IEnumerable<Operation> GetGarageOperations()
        {
            List<string> operationsFullName = AppDomain.CurrentDomain.GetAssemblies()
                                               .SelectMany(i_X => i_X.GetTypes())
                                               .Where(i_X => typeof(Operation).IsAssignableFrom(i_X) && !i_X.IsInterface && !i_X.IsAbstract)
                                               .Select(i_X => i_X.FullName).ToList();

            foreach(string operationFullName in operationsFullName)
            {
                Type t = Type.GetType(operationFullName);
                if(t != null)
                {
                    Operation operation = Activator.CreateInstance(t) as Operation;
                    if(operation != null)
                    {
                        yield return operation;
                    }
                }
            }
        }
    }
}
