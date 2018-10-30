using System;
using System.Collections.Generic;

namespace GarageLogic.Operations
{

    public abstract class Operation : BaseOperation
    {
        public int Index { get; protected set; }

        protected string Details { get; set; }

        public Dictionary<string, Func<string, eOperationStatus>> Instructions { get; protected set; }

        public override string ToString()
        {
            return $"{Index}. {Details}";
        }
    }
}
