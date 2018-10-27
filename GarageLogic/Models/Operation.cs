using System;
using System.Collections.Generic;
using GarageLogic.Interfaces;

namespace GarageLogic.Models
{
    public enum eOperationStatus
    {
        Starting,
        CanProceed,
        Completed,
        //TryAgain,
    }
    public abstract class Operation
    {
        protected IGarageManager m_GarageManager;
        public int Index { get; set; }

        protected string Details { get; set; }

        public Dictionary<string, Func<string, eOperationStatus>> Instructions { get; set; }

        public string OperationResult;
 
        public override string ToString()
        {
            return $"{Index}. {Details}";
        }
    }
}
