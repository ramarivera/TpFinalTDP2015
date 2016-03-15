﻿using MarrSystems.TpFinalTDP2015.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarrSystems.TpFinalTDP2015.Persistence
{
    public interface IPersistenceFactory
    {
        IUnitOfWork CreateUnitOfWork();

        IRepository<T> CreateRepository<T>(IUnitOfWork pUoW) where T : BaseEntity;
    }
}