using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;
using Microsoft.Practices.Unity;
using MarrSystems.TpFinalTDP2015.CrossCutting.DependencyInjection;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.Services
{
    public class ServiceFactory
    {
        public static BaseService<TDto> GetService<TDto>() where TDto : IDTO
            //TODO revisar ewsto porque NO TODOS los idto tienen un controlador
        {
            dynamic lResult;
            if (typeof(TDto) == typeof(DateIntervalDTO))
            {
                lResult = IoCContainerLocator.
                    Container.
                    Resolve(typeof(DateIntervalService));
            }
            else if (typeof(TDto) == typeof(StaticTextDTO))
            {
                lResult = IoCContainerLocator.
                    Container.
                    Resolve(typeof(StaticTextService));
            }
            else if (typeof(TDto) == typeof(RssSourceDTO))
            {
                lResult = IoCContainerLocator.
                    Container.
                    Resolve(typeof(RssSourceService));
            }
            else if (typeof(TDto) == typeof(AdminBannerDTO))
            {
                lResult = IoCContainerLocator.
                    Container.
                    Resolve(typeof(BannerService));
            }
            else
            {
                throw new ArgumentException();
            }

            return (BaseService<TDto>) lResult;
        }

}
}
