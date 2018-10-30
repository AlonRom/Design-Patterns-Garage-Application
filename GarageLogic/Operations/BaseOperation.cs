using System;
using System.Collections.Generic;
using GarageLogic.Interfaces;

namespace GarageLogic.Operations
{
    public enum eOperationStatus
    {
        Starting,
        CanProceed,
        CanProceedToSubMenu,
        Completed
    }

    public abstract class BaseOperation
    {
        protected IGarageManager m_GarageManager;
        public Dictionary<string, Func<string, eOperationStatus>> SubMenuInstructions { get; protected set; }

        public string m_OperationResult;

    }
}
