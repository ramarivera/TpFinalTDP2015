﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarrSystems.TpFinalTDP2015.Model;

namespace MarrSystems.TpFinalTDP2015.Persistence
{
    public interface IUnitOfWork : IDisposable //TODO pasar IDisposable a las implementaciones
    {
        void Commit();
        void Rollback();
        void BeginTransaction();
    }

}
