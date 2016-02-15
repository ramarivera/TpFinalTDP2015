using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Logging;
using TpFinalTDP2015.Persistence.Interfaces;
using Microsoft.Practices.Unity;
using TpFinalTDP2015.Model;
using TpFinalTDP2015.Service.DTO;
using AutoMapper;


namespace TpFinalTDP2015.Service.Controllers
{
    public class StaticTextController
    {
        /// <summary>
        /// Definición de logger para todas las instancias de la clase.
        /// </summary>
        private static readonly ILog cLogger = LogManager.GetLogger<StaticTextController>();

        private IUnitOfWork iUoW;


        public StaticTextController()
        {
        }

        private IUnitOfWork GetUnitOfWork()
        {
            return IoCUnityContainerLocator.Container.Resolve<IUnitOfWork>();
        }

        public IList<StaticTextDTO> GetStaticTexts()
        {
            IList<StaticTextDTO> lResult = new List<StaticTextDTO>();

            using (this.iUoW = GetUnitOfWork())
            {
                IRepository<StaticText> lRepo = iUoW.GetRepository<StaticText>();
                IList<StaticText> lTemp = lRepo.GetAll().ToList();

                foreach (var staticText in lTemp)
                {
                    StaticTextDTO lDto = Mapper.Map<StaticText, StaticTextDTO>(staticText);
                    lResult.Add(lDto);
                }
            }
            return lResult;
        }

        public void SaveStaticText(StaticTextDTO pStaticText)
        {
            using (this.iUoW = GetUnitOfWork())
            {
                iUoW.BeginTransaction();
                IRepository<StaticText> lRepo = iUoW.GetRepository<StaticText>();
                StaticText lStaticText = Mapper.Map<StaticTextDTO, StaticText>(pStaticText);
                if (pStaticText.Id == 0)
                {
                    lRepo.Add(lStaticText);
                }
                else
                {
                    lRepo.Update(lStaticText);
                }
                iUoW.Commit();
            }
        }

        public void DeleteStaticText(StaticTextDTO pStaticText)
        {
            using (this.iUoW = GetUnitOfWork())
            {
                iUoW.BeginTransaction();
                IRepository<StaticText> lRepo = iUoW.GetRepository<StaticText>();
                StaticText lStaticText = Mapper.Map<StaticTextDTO, StaticText>(pStaticText);
                lRepo.Delete(lStaticText.Id);
                iUoW.Commit();
            }
        }
    }
}
