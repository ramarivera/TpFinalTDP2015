using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.UseCaseControllers
{
    public interface IControllerFactory
    {
        IController GetController(Type pType);
        T GetController<T>() where T : IController;
    }
}
