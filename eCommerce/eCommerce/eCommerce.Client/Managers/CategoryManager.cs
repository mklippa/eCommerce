using System;
using System.Collections.Generic;
using eCommerce.Client.Objects;

namespace eCommerce.Client.Managers
{
    public class CategoryManager
    {
        private readonly List<Category> _categories; 

        public CategoryManager()
        {
            #region [SPORT CATEGORIES]
            var sportCategory = new Category
            {
                Id = Guid.Parse("b91f81d7-5767-46a5-9e26-d9b579fafcf1"),
                Name = "Sport"
            };
            var sportHockeyCategory = new Category
            {
                Id = Guid.Parse("d161c2f9-9465-4c28-abca-7fc8661699d4"),
                Name = "Hockey"
            };
            var sportFootballCategory = new Category
            {
                Id = Guid.Parse("a4419a65-9d50-4063-8bb5-b2d0e5ccd6ed"),
                Name = "Football"
            };
            var sportBasketballCategory = new Category
            {
                Id = Guid.Parse("a4bea0b9-92ed-46bc-bd2a-c5d93117dc91"),
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
                Id = Guid.Parse("dbf2d97f-9e85-4838-9ce1-9c2672cd8526"),
                Name = "Food"
            };
            var foodMeatCategory = new Category
            {
                Id = Guid.Parse("01c0a5da-bb76-4547-86a5-ab742439e4de"),
                Name = "Meat"
            };
            var foodPlantCategory = new Category
            {
                Id = Guid.Parse("b148dbf1-8780-49a4-b823-29da4059e0da"),
                Name = "Plant Food"
            };
            var foodConfectionCategory = new Category
            {
                Id = Guid.Parse("5352b8d3-6a86-44ea-a329-362e1cf9a67a"),
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
                Id = Guid.Parse("3ea2f0c6-b0c1-4f62-958b-e0a0e74baf80"),
                Name = "Game"
            };
            var gameActionCategory = new Category
            {
                Id = Guid.Parse("88447e6a-d63e-4fc1-8304-ee3faf24a042"),
                Name = "Action"
            };
            var gameRpgCategory = new Category
            {
                Id = Guid.Parse("08086b04-8011-4197-87e6-3f848a0d96fa"),
                Name = "RPG"
            };
            var gameArcadeCategory = new Category
            {
                Id = Guid.Parse("561aafdf-50fb-406b-9f95-2a2e155e9455"),
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