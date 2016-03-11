using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;
using MarrSystems.TpFinalTDP2015.BusinessLogic.Services;
using MarrSystems.TpFinalTDP2015.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.UseCaseControllers
{
    public class ManageBannerHandler
    {
        public void AddBanner(AdminBannerDTO pDto) { }
        /* {
             using (var serv = BusinessServiceLocator.Resolve<BannerService>())
             {
                 Banner lBanner = Mapper.Map<AdminBannerDTO, Banner>(pDto);
                 serv.Save(lBanner);
             }
         }*/

        public void ModifyBanner(AdminBannerDTO pDto) { }
        //TODO: update

        public void DeleteBanner(int pId)
        {
            using (var serv = BusinessServiceLocator.Resolve<BannerService>())
            {
                serv.Delete(pId);
            }
        }

        public IList<AdminBannerDTO> ListBanner()
        {
            IList<AdminBannerDTO> lResult = new List<AdminBannerDTO>();

            using (var serv = BusinessServiceLocator.Resolve<BannerService>())
            {
                foreach (var banner in serv.GetAll())
                {
                    AdminBannerDTO lDto = Mapper.Map<Banner, AdminBannerDTO>(banner);
                    lResult.Add(lDto);
                }
            }
            return lResult;
        }

        public AdminBannerDTO GetBanner(int pId)
        {
            AdminBannerDTO lResult = new AdminBannerDTO();

            using (var serv = BusinessServiceLocator.Resolve<BannerService>())
            {
                lResult = Mapper.Map<Banner, AdminBannerDTO>(serv.Get(pId));
            }
            return lResult;
        }
    }
}
