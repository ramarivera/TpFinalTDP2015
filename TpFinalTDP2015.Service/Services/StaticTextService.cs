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
    public class StaticTextService : BaseService<StaticText>
    {
        /// <summary>
        /// Definición de logger para todas las instancias de la clase.
        /// </summary>
        private static readonly ILog cLogger = LogManager.GetLogger<StaticTextService>();

        public StaticTextService(IUnitOfWork iUoW) : base(iUoW)
        {
        }

        public override int Save(StaticText pStaticText)
        {
            iUoW.BeginTransaction();
            IRepository<StaticText> lRepo = iUoW.GetRepository<StaticText>();

            if (pStaticText.Id == 0)
            {
                lRepo.Add(pStaticText);
            }
            else
            {
                lRepo.Update(pStaticText);
            }
            iUoW.Commit();
            return pStaticText.Id;
        }

        public override void Delete(int pId)
        {
            iUoW.BeginTransaction();
            IRepository<StaticText> lRepo = iUoW.GetRepository<StaticText>();
            
            lRepo.Delete(pId);
            iUoW.Commit();
        }

        public override IList<StaticText> GetAll()
        {
            IList<StaticText> lResult = new List<StaticText>();

            IRepository<StaticText> lRepo = iUoW.GetRepository<StaticText>();
            IList<StaticText> lTemp = lRepo.GetAll().ToList();

            foreach (var staticText in lTemp)
            {
                lResult.Add(staticText);
            }
            return lResult;//.ToList<StaticText>();
        }

        public override StaticText Get(int pId)
        {
            StaticText lResult = new StaticText();
            IRepository<StaticText> lRepo = iUoW.GetRepository<StaticText>();
            lResult = lRepo.GetByID(pId);
            return lResult;
        }
    }
}
