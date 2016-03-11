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
    public class ManageCampaignHandler
    {
        public void AddCampaign(CampaignDTO pDto) { }

        public void ModifyCampaign(CampaignDTO pDto) { }
        //TODO: update

        public void DeleteCampaign(CampaignDTO pDto)
        {
            using (var serv = BusinessServiceLocator.Resolve<CampaignService>())
            {
                serv.Delete(pDto.Id);
            }
        }

        public IList<CampaignDTO> ListCampaign()
        {
            IList<CampaignDTO> lResult = new List<CampaignDTO>();

            using (var serv = BusinessServiceLocator.Resolve<CampaignService>())
            {
                foreach (var campaign in serv.GetAll())
                {
                    CampaignDTO lDto = Mapper.Map<Campaign, CampaignDTO>(campaign);
                    lResult.Add(lDto);
                }
            }
            return lResult;
        }

        public CampaignDTO GetCampaign(int pId)
        {
            CampaignDTO lResult = new CampaignDTO();

            using (var serv = BusinessServiceLocator.Resolve<CampaignService>())
            {
                lResult = Mapper.Map<Campaign, CampaignDTO>(serv.Get(pId));
            }
            return lResult;
        }
    }
}
