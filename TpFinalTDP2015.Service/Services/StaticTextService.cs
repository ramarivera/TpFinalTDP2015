using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Logging;
using MarrSystems.TpFinalTDP2015.Persistence;
using Microsoft.Practices.Unity;
using MarrSystems.TpFinalTDP2015.Model;
using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;
using AutoMapper;


namespace MarrSystems.TpFinalTDP2015.BusinessLogic.Services
{
    public class StaticTextService : BaseService<StaticTextDTO>
    {
        /// <summary>
        /// Definición de logger para todas las instancias de la clase.
        /// </summary>
        private static readonly ILog cLogger = LogManager.GetLogger<StaticTextService>();

        public StaticTextService(IUnitOfWork iUoW) : base(iUoW)
        {
        }

        public override int Save(StaticTextDTO pStaticText)
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
            return lStaticText.Id;
        }

        public override void Delete(StaticTextDTO pStaticText)
        {
            iUoW.BeginTransaction();
            IRepository<StaticText> lRepo = iUoW.GetRepository<StaticText>();
            StaticText lStaticText = Mapper.Map<StaticTextDTO, StaticText>(pStaticText);
            lRepo.Delete(lStaticText.Id);
            iUoW.Commit();
        }

        public override IList<StaticTextDTO> GetAll()
        {
            IList<StaticTextDTO> lResult = new List<StaticTextDTO>();

            IRepository<StaticText> lRepo = iUoW.GetRepository<StaticText>();
            IList<StaticText> lTemp = lRepo.GetAll().ToList();

            foreach (var staticText in lTemp)
            {
                StaticTextDTO lDto = Mapper.Map<StaticText, StaticTextDTO>(staticText);
                lResult.Add(lDto);
            }
            return lResult.ToList<StaticTextDTO>();
        }

        public override StaticTextDTO Get(int pId)
        {
            StaticTextDTO lResult = new StaticTextDTO();

            IRepository<StaticText> lRepo = iUoW.GetRepository<StaticText>();

            var lTemp = lRepo.GetByID(pId);

            lResult = Mapper.Map<StaticText, StaticTextDTO>(lTemp);

            return lResult;
        }
    }
}
