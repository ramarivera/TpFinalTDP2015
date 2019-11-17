using System;
using System.Linq;
using Questionnaire.Model;
using Questionnaire.Persistence.Repository;
using Questionnaire.Services.DTO;
using NHibernate;
using Questionnaire.Services.Interfaces;

namespace Questionnaire.Services
{
    public class DifficultyServices : IDifficultyServices
    {
        private readonly IRepository<Difficulty> iDifficultyRepository;
        public DifficultyServices(IRepository<Difficulty> pDifficultyRepository)
        {
            this.iDifficultyRepository = pDifficultyRepository;
        }
        
        /// <summary>
        /// Persist a Difficulty in the database
        /// </summary>
        /// <param name="pDifficultyData"></param>
        /// <returns></returns>
        public Difficulty Create(DifficultyData pDifficultyData)
        {
            Difficulty lDifficulty = new Difficulty
            {
                Description = pDifficultyData.Description
            };

            this.iDifficultyRepository.Add(lDifficulty);

            return lDifficulty;
        }

        public void Delete(long pId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Difficulty> GetAll()
        {
            return this.iDifficultyRepository.GetAll();
        }      

        public Difficulty GetById(long pDifficultyId)
        {
            var lDifficulty = this.iDifficultyRepository.GetById(pDifficultyId);

            if (lDifficulty == null)
            {
                throw new ArgumentException($"Difficulty with Id {pDifficultyId} was not found");
            }

            return lDifficulty;
        }

        public Difficulty Update(long pId, DifficultyData pUpdateDifficulty)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieve a Difficulty by description, if it doesn´t exist create it
        /// </summary>
        /// <param name="pDifficultyDescription"></param>
        /// <returns></returns>
        public DifficultyData RetrieveByDescription(string pDifficultyDescription)
        {
            var lDifficulty = this.GetAll()
                    .FirstOrDefault(x => x.Description == pDifficultyDescription);

            if (lDifficulty == null)
            {
                var lDifficultyCreationData = new DifficultyData
                {
                    Description = pDifficultyDescription
                };

                lDifficulty = this.Create(lDifficultyCreationData);
            }

            DifficultyData lDifficultyData = new DifficultyData
            {
                Id = lDifficulty.Id,
                Description = pDifficultyDescription
            };

            return lDifficultyData;
        }

        /// <summary>
        /// Retrieve a Difficulty Factor according to a given description
        /// </summary>
        /// <param name="pDescription"></param>
        /// <returns></returns>
        public int GetDifficultyFactor(string pDescription)
        {
            int lDifficultyFactor = 0;

            if (pDescription == "easy") { lDifficultyFactor = 1; }
            else if (pDescription == "medium") { lDifficultyFactor = 3; }
            else if (pDescription == "hard") { lDifficultyFactor = 5; }

            return lDifficultyFactor;
        }
    }
}
