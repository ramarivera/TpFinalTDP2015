﻿using Cuestionario.Model;
using Cuestionario.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuestionario.Services.Interfaces
{
    public interface IDifficultyServices
    {
        IQueryable<Difficulty> GetAll();
        Difficulty GetById(long pDifficultyId);
        //Difficulty Create(DifficultyCreationData pDifficultyData);
        Difficulty Create(DifficultyData pDifficultyData);
        Difficulty Update(long pDifficultyId, DifficultyData pUpdateDifficulty);
        void Delete(long pDifficultyId);
        DifficultyData RetrieveByDescription(string pDifficultyDescription);
    }
}