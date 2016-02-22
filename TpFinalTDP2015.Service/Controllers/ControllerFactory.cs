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
            else if (typeof(TDto) == typeof(StaticTextDTO))
            {
                lResult = IoCUnityContainerLocator.
                    Container.
                    Resolve(typeof(StaticTextController));
            }
            else if (typeof(TDto) == typeof(RssSourceDTO))
            {
                lResult = IoCUnityContainerLocator.
                    Container.
                    Resolve(typeof(RssSourceController));
            }
            else if (typeof(TDto) == typeof(AdminBannerDTO))
            {
                lResult = IoCUnityContainerLocator.
                    Container.
                    Resolve(typeof(BannerController));
            }
            else
            {
                throw new ArgumentException();
            }

            return (BaseController<TDto>) lResult;
        }

}
}
