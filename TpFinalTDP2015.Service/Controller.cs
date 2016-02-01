using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Logging;
using TpFinalTDP2015.Persistence.Interfaces;
using Microsoft.Practices.Unity;
using TpFinalTDP2015.Model;
using TpFinalTDP2015.Persistence.EntityFramework;

namespace TpFinalTDP2015.Service
{
    public class Controller //: IController
    {
        /// <summary>
        /// Definición de logger para todas las instancias de la clase.
        /// </summary>
        private static readonly ILog cLogger = LogManager.GetLogger<Controller>();

        private IUnitOfWork iUoW;


        public Controller()
        {
            cLogger.Info("Fachada instanciada");

            using (this.iUoW = IoCUnityContainerLocator.Container.Resolve<IUnitOfWork>())
            {
                iUoW.BeginTransaction();

                cLogger.InfoFormat("Usando {0} como implementacion de {1}", new[] { this.iUoW.GetType().Name, typeof(IUnitOfWork).Name });


                iUoW.Commit();
            }
        }

        public void CreateCampaign(Campaign pCampaign)
        {
            using (this.iUoW)
            {
                iUoW.BeginTransaction();
                IRepository<Campaign> lRepo = iUoW.GetRepository<Campaign>();
                lRepo.Add(pCampaign);
                iUoW.Commit();
            }
        }

        public void UpdateCampaign(Campaign pCampaign)
        {
            using (this.iUoW)
            {
                iUoW.BeginTransaction();
                IRepository<Campaign> lRepo = iUoW.GetRepository<Campaign>();
                lRepo.Update(pCampaign);
                iUoW.Commit();
            }
        }

        public void DeleteCampaign(Campaign pCampaign)
        {
            using (this.iUoW)
            {
                iUoW.BeginTransaction();
                IRepository<Campaign> lRepo = iUoW.GetRepository<Campaign>();
                Campaign mCampaign = lRepo.GetByID(pCampaign.Id);
                lRepo.Delete(mCampaign);
                iUoW.Commit();
            }

        }

        /*public List<Campaign> GetAllCampaigns()
        {
            List<Campaign> lResultado = new List<Campaign>();
            using (this.iUoW)
            {
                IRepository<Campaign> lRepo = iUoW.GetRepository<Campaign>();
                var query = lRepo.Queryable. Include(p => p.);
                lResultado = query.ToList<Persona>();
            }
            return lResultado;*/

        }
        //public 
    }
