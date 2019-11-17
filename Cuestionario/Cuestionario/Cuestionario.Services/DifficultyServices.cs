using System;
using System.Linq;
using Questionnaire.Model;
using Questionnaire.Persistence.Repository;
using Questionnaire.Services.DTO;
using Questionnaire.Services.Interfaces;
using System.Collections.Generic;

namespace Questionnaire.Services
{
    /// <summary>
    /// Contains all business logic related to <see cref="Difficulty"/> model class
    /// </summary>
    public class DifficultyServices : IDifficultyServices
    {
        private readonly IRepository<Difficulty> iDifficultyRepository;
        public DifficultyServices(IRepository<Difficulty> pDifficultyRepository)
        {
            this.iDifficultyRepository = pDifficultyRepository;
        }

        /// <summary>
        /// Creates a new <see cref="Difficulty"/> that will be stored
        /// </summary>
        /// <param name="pDifficultyData">New <see cref="Difficulty"/> data</param>
        /// <returns>Created <see cref="Difficulty"/></returns>
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

        /// <summary>
        /// Gets all stored <see cref="Difficulty"/>
        /// </summary>
        /// <returns>A list of <see cref="Difficulty"/></returns>
        public IEnumerable<Difficulty> GetAll()
        {
            return this.iDifficultyRepository.GetAll();
        }

        /// <summary>
        /// Gets a specific <see cref="Difficulty"/>
        /// </summary>
        /// <param name="pDifficultyId">Specific <see cref="Difficulty"/> Id</param>
        /// <returns>A <see cref="Difficulty"/></returns>
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
        /// Retrieve a <see cref="Difficulty"/> by description. If it doesn´t exist, creates it
        /// </summary>
        /// <param name="pDifficultyDescription"><see cref="Category"/> description</param>
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
            //TODO RAR review this
            int lDifficultyFactor = 0;

            if (pDescription == "easy") { lDifficultyFactor = 1; }
            else if (pDescription == "medium") { lDifficultyFactor = 3; }
            else if (pDescription == "hard") { lDifficultyFactor = 5; }

            return lDifficultyFactor;
        }
    }
}
