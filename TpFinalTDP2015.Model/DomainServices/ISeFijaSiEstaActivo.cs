using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarrSystems.TpFinalTDP2015.Model.DomainServices
{
    public interface ISeFijaSiEstaActivo
    {
        bool IsActiveAt(ICosoQueTieneDateInterval pCoso, DateTime pDate);
    }
}
