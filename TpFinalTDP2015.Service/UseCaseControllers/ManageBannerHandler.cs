using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;
using MarrSystems.TpFinalTDP2015.BusinessLogic.Services;
using MarrSystems.TpFinalTDP2015.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarrSystems.TpFinalTDP2015.Persistence;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.UseCaseControllers
{
    public class ManageBannerHandler : IController
    {
        private readonly IUnitOfWork iUoW;
        private readonly IBannerService iServ;

        public ManageBannerHandler(IUnitOfWork pUow, IBannerService pServ)
        {
            this.iUoW = pUow;
            this.iServ = pServ;
        }

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
        }

        public IList<AdminBannerDTO> ListBanner()
        {
            IList<AdminBannerDTO> lResult = new List<AdminBannerDTO>();

                foreach (var banner in iServ.GetAll())
                {
                    AdminBannerDTO lDto = Mapper.Map<Banner, AdminBannerDTO>(banner);
                    lResult.Add(lDto);
                }
            return lResult;
        }

        public AdminBannerDTO GetBanner(int pId)
        {
            AdminBannerDTO lResult = new AdminBannerDTO();

                lResult = Mapper.Map<Banner, AdminBannerDTO>(iServ.Read(pId));
            return lResult;
        }
    }
}
