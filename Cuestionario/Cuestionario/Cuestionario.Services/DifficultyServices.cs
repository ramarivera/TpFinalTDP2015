﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Questionnaire.Model;
using Questionnaire.Services.DTO;
using NHibernate;
using Questionnaire.Services.Interfaces;

namespace Questionnaire.Services
{
    public class DifficultyServices : IDifficultyServices
    {
        private ISession iSession;
        public DifficultyServices(ISession pSession)
        {
            iSession = pSession;
        }
        public Difficulty Create(DifficultyData pDifficultyData)
        {
            Difficulty lDifficulty = new Difficulty
            {
                Description = pDifficultyData.Description
            };

            iSession.Save(lDifficulty);

            return lDifficulty;
        }

        public void Delete(long pId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Difficulty> GetAll()
        {
            IQueryable<Difficulty> lCategories =
                iSession.Query<Difficulty>();

            return lCategories;
        }      

        public Difficulty GetById(long pDifficultyId)
        {
            var lDifficulty = GetAll()
                .FirstOrDefault(x => x.Id == pDifficultyId);

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

        public DifficultyData RetrieveByDescription(string pDifficultyDescription)
        {
            var lDifficulty = GetAll()
                    .FirstOrDefault(x => x.Description == pDifficultyDescription);

            if (lDifficulty == null)
            {
                var lDifficultyCreationData = new DifficultyData
                {
                    Description = pDifficultyDescription
                };

                lDifficulty = Create(lDifficultyCreationData);
            }

            DifficultyData lDifficultyData = new DifficultyData
            {
                Id = lDifficulty.Id,
                Description = pDifficultyDescription
            };

            return lDifficultyData;
        }

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
