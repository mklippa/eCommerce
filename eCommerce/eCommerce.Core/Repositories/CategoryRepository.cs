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
            #region [SPORT CATEGORIES]
            var sportCategory = new Category
            {
                Id = Guid.NewGuid(),
                Name = "Sport"
            };
            var sportHockeyCategory = new Category
            {
                Id = Guid.NewGuid(),
                Name = "Hockey"
            };
            var sportFootballCategory = new Category
            {
                Id = Guid.NewGuid(),
                Name = "Football"
            };
            var sportBasketballCategory = new Category
            {
                Id = Guid.NewGuid(),
                Name = "Basketball"
            };
            sportCategory.SubCategories = new List<Category>
            {
                sportHockeyCategory, sportFootballCategory, sportBasketballCategory
            };
            #endregion

            #region [FOOD CATEGORIES]
            var foodCategory = new Category
            {
                Id = Guid.NewGuid(),
                Name = "Food"
            };
            var foodMeatCategory = new Category
            {
                Id = Guid.NewGuid(),
                Name = "Meat"
            };
            var foodPlantCategory = new Category
            {
                Id = Guid.NewGuid(),
                Name = "Plant Food"
            };
            var foodConfectionCategory = new Category
            {
                Id = Guid.NewGuid(),
                Name = "Confection"
            };
            foodCategory.SubCategories = new List<Category>
            {
                foodMeatCategory, foodPlantCategory, foodConfectionCategory
            };
            #endregion

            #region [GAME CATEGORY]
            var gameCategory = new Category
            {
                Id = Guid.NewGuid(),
                Name = "Game"
            };
            var gameActionCategory = new Category
            {
                Id = Guid.NewGuid(),
                Name = "Action"
            };
            var gameRpgCategory = new Category
            {
                Id = Guid.NewGuid(),
                Name = "RPG"
            };
            var gameArcadeCategory = new Category
            {
                Id = Guid.NewGuid(),
                Name = "Arcade"
            };
            gameCategory.SubCategories = new List<Category>
            {
                gameActionCategory, gameRpgCategory, gameArcadeCategory
            };
            #endregion

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