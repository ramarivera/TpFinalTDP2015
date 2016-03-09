using AutoMapper;
using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;
using MarrSystems.TpFinalTDP2015.BusinessLogic.Services;
using MarrSystems.TpFinalTDP2015.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.UseCaseControllers
{
    public class ManageSourceHandler
    {
        public int AddSource(RssSourceDTO pDto)
        {
            using (var serv = BusinessServiceLocator.Resolve<RssSourceService>())
            {
                RssSource lSource = Mapper.Map<RssSourceDTO, RssSource>(pDto);
                serv.Save(lSource);
                return lSource.Id;
            }
        }

        public void ModifySource(RssSourceDTO pDto)
        {
            using (var serv = BusinessServiceLocator.Resolve<RssSourceService>())
            {
                RssSource lSource = Mapper.Map<RssSourceDTO, RssSource>(pDto);
                serv.Save(lSource);
            }
        }

        public void DeleteSource(RssSourceDTO pDto)
        {
            using (var serv = BusinessServiceLocator.Resolve<RssSourceService>())
            {
                serv.Delete(pDto.Id);
            }
        }


        public IList<RssSourceDTO> ListSources()
        {
            IList<RssSourceDTO> lResult = new List<RssSourceDTO>();

            using (var serv = BusinessServiceLocator.Resolve<RssSourceService>())
            {
                foreach (var rss in serv.GetAll())
                {
                    RssSourceDTO lDto = Mapper.Map<RssSource, RssSourceDTO>(rss);
                    lResult.Add(lDto);
                }
            }

            return lResult;
        }

        public RssSourceDTO GetSource(int pId)
        {
            RssSourceDTO lResult = new RssSourceDTO();

            using (var serv = BusinessServiceLocator.Resolve<RssSourceService>())
            {
                lResult = Mapper.Map<RssSource, RssSourceDTO>(serv.Get(pId));
            }
            return lResult;
        }
    }
}
