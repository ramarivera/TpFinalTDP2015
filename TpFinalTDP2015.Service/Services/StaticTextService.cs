using log4net;
using MarrSystems.TpFinalTDP2015.Model;
using MarrSystems.TpFinalTDP2015.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.Services
{
    public class StaticTextService :  IStaticTextService
    {
        /// <summary>
        /// Definición de logger para todas las instancias de la clase.
        /// </summary>
        private static readonly ILog cLogger = MarrSystems.TpFinalTDP2015.CrossCutting.Logging.LogManagerWrapper.GetLogger<StaticTextService>();
        private readonly IRepository<StaticText> iRepo;

        public StaticTextService(IRepository<StaticText> pRepo) //TODO  revisame, sacame Uow
        {
            this.iRepo = pRepo;
        }

        int ICrudService<StaticText>.Create(StaticText pStaticText)
        {
            iRepo.Add(pStaticText);
            return pStaticText.Id;
        }

        StaticText ICrudService<StaticText>.Read(int pId)
        {
            return iRepo.GetByID(pId); //TODO revisar si esto sigue estando o no o whaaaaat
        }

        int ICrudService<StaticText>.Update(StaticText pStaticText)
        {
            iRepo.Update(pStaticText);
            return pStaticText.Id;
        }

        void ICrudService<StaticText>.Delete(int pId)
        {
            iRepo.Delete(pId);
        }

        IEnumerable<StaticText> ICrudService<StaticText>.GetAll()
        {
            return iRepo.GetAll().ToList();
        }
    }
}