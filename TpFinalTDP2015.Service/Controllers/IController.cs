﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TpFinalTDP2015.Service.DTO;

namespace TpFinalTDP2015.Service.Controllers
{
    interface IController<TDto> : IDisposable where TDto : IDTO
    {

        IList<TDto> GetAll();

        void Delete(TDto pId);

        void Save(TDto pDTO);
    }
}