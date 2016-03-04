using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.Services
{
   public interface IService<TDto> : IDisposable where TDto : IDTO
    {

        IList<TDto> GetAll();

        TDto Get(int pId);

        void Delete(TDto pDTO);

        int Save(TDto pDTO);
    }
}
