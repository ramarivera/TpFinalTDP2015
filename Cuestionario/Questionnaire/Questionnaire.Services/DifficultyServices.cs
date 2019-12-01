using Questionnaire.Model;
using Questionnaire.Model.Enums;
using Questionnaire.Persistence.Repository;
using Questionnaire.Services.DTO;
using Questionnaire.Services.Interfaces;
using Questionnaire.Services.Specifications.Difficulties;
using System;
using System.Collections.Generic;
using System.Linq;

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

        /// <summary>
        /// Gets all stored <see cref="Difficulty"/>
        /// </summary>
        /// <returns>A list of <see cref="Difficulty"/></returns>
        public IEnumerable<Difficulty> GetAll()
        {
            return this.iDifficultyRepository.ToList();
        }

        /// <summary>
        /// Gets a specific <see cref="Difficulty"/>
        /// </summary>
        /// <param name="pDifficultyId">Specific <see cref="Difficulty"/> Id</param>
        /// <returns>A <see cref="Difficulty"/></returns>
        public Difficulty GetById(int pDifficultyId)
        {
            var lDifficulty = this.iDifficultyRepository.FindById(pDifficultyId);

            if (lDifficulty == null)
            {
                throw new ArgumentException($"Difficulty with Id {pDifficultyId} was not found");
            }

            return lDifficulty;
        }

        /// <summary>
        /// Retrieve a <see cref="Difficulty"/> by description. If it doesn´t exist, creates it
        /// </summary>
        /// <param name="pDifficultyDescription"><see cref="Category"/> description</param>
        /// <returns></returns>
        public DifficultyData RetrieveByDescription(string pDifficultyDescription)
        {
            var lDifficulty = this.iDifficultyRepository
                    .FindBy(new DifficultyDescriptionSpecification(pDifficultyDescription))
                    .FirstOrDefault();

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

            if (pDescription == "easy") { lDifficultyFactor = (int)DifficultyFactor.Easy; }
            else if (pDescription == "medium") { lDifficultyFactor = (int)DifficultyFactor.Medium; }
            else if (pDescription == "hard") { lDifficultyFactor = (int)DifficultyFactor.Hard; }

            return lDifficultyFactor;
        }
    }
}
