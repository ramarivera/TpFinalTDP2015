using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TpFinalTDP2015.Service.DTO;

namespace TpFinalTDP2015.Service.Controllers
{
    interface IController<TDTO> : IDisposable where TDTO : IDTO
    {

        IList<TDTO> GetAll();

        void Delete(TDTO pId);

        void Save(TDTO pDTO);
    }
}
