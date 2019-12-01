﻿using Questionnaire.Model;
using Questionnaire.Persistence.Repository;
using Questionnaire.Services.DTO;
using Questionnaire.Services.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using Questionnaire.Services.Specifications.Categories;

namespace Questionnaire.Services
{
    /// <summary>
    /// Contains all business logic related to <see cref="Category"/> model class
    /// </summary>
    public class CategoryServices : ICategoryServices
    {
        private readonly IRepository<Category> iCategoryRepository;

        public CategoryServices(IRepository<Category> pCategoryRepository)
        {
            this.iCategoryRepository = pCategoryRepository;
        }

        /// <summary>
        /// Creates a new <see cref="Category"/> that will be stored
        /// </summary>
        /// <param name="pCategoryData">New <see cref="Category"/> data</param>
        /// <returns>Created <see cref="Category"/></returns>
        public Category Create(CategoryData pCategoryData)
        {
            Category lCategory = new Category
            {
                Description = pCategoryData.Description
            };

            this.iCategoryRepository.Add(lCategory);

            return lCategory;
        }

        /// <summary>
        /// Gets all stored <see cref="Category"/>
        /// </summary>
        /// <returns>A list of <see cref="Category"/></returns>
        public IEnumerable<Category> GetAll()
        {
            return this.iCategoryRepository.ToList();
        }

        /// <summary>
        /// Gets a specific <see cref="Category"/>
        /// </summary>
        /// <param name="pCategoryId">Specific <see cref="Category"/> Id</param>
        /// <returns>A <see cref="Category"/></returns>
        public Category GetById(int pCategoryId)
        {
            var lCategory = iCategoryRepository.FindById(pCategoryId);

            if (lCategory == null)
            {
                throw new ArgumentException($"Category with Id {pCategoryId} was not found");
            }

            return lCategory;
        }

        /// <summary>
        /// Retrieve a <see cref="Category"/> by description. If it doesn´t exist, creates it
        /// </summary>
        /// <param name="pCategoryDescription"><see cref="Category"/> description</param>
        /// <returns></returns>
        public CategoryData RetrieveOrCreateByDescription(string pCategoryDescription)
        {
            var lCategory = this.iCategoryRepository
                    .FindBy(new CategoryDescriptionSpecification(pCategoryDescription))
                    .FirstOrDefault();

            if (lCategory == null)
            {
                var lCategoryCreationData = new CategoryData
                {
                    Description = pCategoryDescription
                };

                lCategory = this.Create(lCategoryCreationData);
            }

            CategoryData lCategoryData = new CategoryData
            {
                Id = lCategory.Id,
                Description = pCategoryDescription
            };

            return lCategoryData;
        }
    }
}
