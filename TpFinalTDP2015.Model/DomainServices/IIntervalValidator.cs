﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpFinalTDP2015.Model.DomainServices
{
    public interface IIntervalValidator
    {
        bool CanBeAdded(ICosoQueTieneDateInterval pCoso, DateInterval pInterval);
    }
}
