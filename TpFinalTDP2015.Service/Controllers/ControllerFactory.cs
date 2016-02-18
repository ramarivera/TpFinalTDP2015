using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpFinalTDP2015.Service.DTO;
using Microsoft.Practices.Unity;


namespace TpFinalTDP2015.Service.Controllers
{
    public class ControllerFactory
    {
        private static ControllerFactory cInstance;

        public static BaseController<TDto> GetController<TDto>() where TDto : IDTO
            //TODO revisar ewsto porque NO TODOS los idto tienen un controlador
        {
            dynamic lResult;
            if (typeof(TDto) == typeof(DateIntervalDTO))
            {
                lResult = IoCUnityContainerLocator.
                    Container.
                    Resolve(typeof(DateIntervalController));
            }
            else if (typeof(TDto) == typeof(AdminBannerDTO))
            {
                //lo que sea
                lResult = 5; // esto obvio que tira error
            }
            else
            {
                throw new ArgumentException();
            }

            return (BaseController<TDto>) lResult;
        }

}
}
