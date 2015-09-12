using System;
using System.Collections.Generic;
using eCommerce.Core.Models;

namespace eCommerce.Core.Repositories
{
    public class CategoryRepository
    {
        private readonly List<Category> _categories; 

        public CategoryRepository()
        {
            var sportCategory = new Category
            {
                Id = Guid.NewGuid(),
                Name = "Sport"
            };
            var foodCategory = new Category
            {
                Id = Guid.NewGuid(),
                Name = "Food"
            };
            var gameCategory = new Category
            {
                Id = Guid.NewGuid(),
                Name = "Game"
            };

            _categories = new List<Category>
            {
                sportCategory, foodCategory, gameCategory
            };
        }

        public List<Category> GetAll()
        {
            return _categories;
        } 
    }
}