﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cuestionario.Model;
using Cuestionario.Services.DTO;
using NHibernate;
using Cuestionario.Services.Interfaces;

namespace Cuestionario.Services
{
    public class DifficultyServices : IDifficultyServices
    {
        private ISession _session;
        public DifficultyServices(ISession session)
        {
            _session = session;
        }
        public Difficulty Create(DifficultyDTO pDifficulty)
        {
            Difficulty lDifficulty = new Difficulty
            {
                Description = pDifficulty.Description
            };

            _session.Save(lDifficulty);
            _session.Transaction.Commit();

            return lDifficulty;
        }

        public void Delete(long pId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Difficulty> GetAll()
        {
            IQueryable<Difficulty> lCategories =
                _session.Query<Difficulty>();

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

        public Difficulty Update(long pId, DifficultyDTO pUpdateDifficulty)
        {
            throw new NotImplementedException();
        }

        public Difficulty GetByDescription(string pDifficultyDescription)
        {
            var lDifficulty = GetAll()
                    .FirstOrDefault(x => x.Description == pDifficultyDescription);

            if (lDifficulty == null)
            {
                var lDifficultyDTO = new DifficultyDTO
                {
                    Description = pDifficultyDescription
                };

                lDifficulty = Create(lDifficultyDTO);
            }

            return lDifficulty;
        }
    }
}
