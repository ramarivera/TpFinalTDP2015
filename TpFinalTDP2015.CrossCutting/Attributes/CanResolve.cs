using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarrSystems.TpFinalTDP2015.CrossCutting.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CanResolve : Attribute
    {
        public Type[] ResolvableTypes { get; set; }

        public CanResolve(params Type[] values)
        {
            this.ResolvableTypes = values;
        }
    }
}