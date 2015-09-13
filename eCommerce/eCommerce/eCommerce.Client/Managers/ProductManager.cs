using System;
using System.Collections.Generic;
using System.Linq;
using eCommerce.Client.Objects;

namespace eCommerce.Client.Managers
{
    public class ProductManager
    {
        private readonly List<Product> _products;

        public ProductManager()
        {
            _products = new List<Product>
            {
                #region [HOCKEY PRODUCTS]
                new Product
                {
                    Id = Guid.Parse("ce3e7a57-547e-432d-85dc-5aba222608a2"),
                    Name = "Skates",
                    CategoryId = Guid.Parse("d161c2f9-9465-4c28-abca-7fc8661699d4")
                },
                new Product
                {
                    Id = Guid.Parse("f83ea021-596b-401e-9d10-e77f8f99d159"),
                    Name = "Hockey-Stick",
                    CategoryId = Guid.Parse("d161c2f9-9465-4c28-abca-7fc8661699d4")
                },
                #endregion

                #region [FOOTBALL PRODUCTS]
                new Product
                {
                    Id = Guid.Parse("8b993412-03e3-4041-8a52-3356d2967a52"),
                    Name = "Ball",
                    CategoryId = Guid.Parse("a4419a65-9d50-4063-8bb5-b2d0e5ccd6ed")
                },
                new Product
                {
                    Id = Guid.Parse("c3317d2b-dd24-47fa-a896-49f87c73a370"),
                    Name = "Football Boots",
                    CategoryId = Guid.Parse("a4419a65-9d50-4063-8bb5-b2d0e5ccd6ed")
                },
                #endregion

                #region [BASKETBALL PRODUCTS]
                new Product
                {
                    Id = Guid.Parse("f8c92737-dddd-4923-9124-be013fc0fc37"),
                    Name = "Ball",
                    CategoryId = Guid.Parse("a4bea0b9-92ed-46bc-bd2a-c5d93117dc91")
                },
                new Product
                {
                    Id = Guid.Parse("770eed22-505e-4227-9d88-c5a73e75e164"),
                    Name = "Sneakers",
                    CategoryId = Guid.Parse("a4bea0b9-92ed-46bc-bd2a-c5d93117dc91")
                },
                #endregion

                #region [MEAT PRODUCTS]
                new Product
                {
                    Id = Guid.Parse("dc7d8323-ddfe-489a-a298-bbb2941edca7"),
                    Name = "Beef",
                    CategoryId = Guid.Parse("01c0a5da-bb76-4547-86a5-ab742439e4de")
                },
                new Product
                {
                    Id = Guid.Parse("472927e4-c1c3-46bb-978f-2744ffa64ff9"),
                    Name = "Pork",
                    CategoryId = Guid.Parse("01c0a5da-bb76-4547-86a5-ab742439e4de")
                },
                #endregion

                #region [PLANT PRODUCTS]
                new Product
                {
                    Id = Guid.Parse("5e746ed0-39f1-4a70-bf11-590eb89ae4c9"),
                    Name = "Apple",
                    CategoryId = Guid.Parse("b148dbf1-8780-49a4-b823-29da4059e0da")
                },
                new Product
                {
                    Id = Guid.Parse("41919fe1-b238-4813-9f7d-9a0f1b4f90cc"),
                    Name = "Banana",
                    CategoryId = Guid.Parse("b148dbf1-8780-49a4-b823-29da4059e0da")
                },
                #endregion

                #region [CONFECTION PRODUCTS]
                new Product
                {
                    Id = Guid.Parse("22302c25-5cc7-468d-9b97-3432f84f3844"),
                    Name = "Candies",
                    CategoryId = Guid.Parse("5352b8d3-6a86-44ea-a329-362e1cf9a67a")
                },
                new Product
                {
                    Id = Guid.Parse("5e5d2a33-ee85-4518-be3c-965d48a36b50"),
                    Name = "Ice Cream",
                    CategoryId = Guid.Parse("5352b8d3-6a86-44ea-a329-362e1cf9a67a")
                },
                #endregion

                #region [ACTION PRODUCTS]
                new Product
                {
                    Id = Guid.Parse("2724c2b7-2ee7-4ada-8c2b-38332404f009"),
                    Name = "Call of Duty",
                    CategoryId = Guid.Parse("88447e6a-d63e-4fc1-8304-ee3faf24a042")
                },
                new Product
                {
                    Id = Guid.Parse("3242140f-96ad-4a39-a71f-13c5d3f21164"),
                    Name = "Battlefield",
                    CategoryId = Guid.Parse("88447e6a-d63e-4fc1-8304-ee3faf24a042")
                },
                #endregion

                #region [RPG PRODUCTS]
                new Product
                {
                    Id = Guid.Parse("199e58b8-6086-4195-a5b4-3c5657f634c2"),
                    Name = "Dragon Age",
                    CategoryId = Guid.Parse("08086b04-8011-4197-87e6-3f848a0d96fa")
                },
                new Product
                {
                    Id = Guid.Parse("33f5efe8-2626-48d0-b163-3bba552980b0"),
                    Name = "The Elder Scrolls",
                    CategoryId = Guid.Parse("08086b04-8011-4197-87e6-3f848a0d96fa")
                },
                #endregion

                #region [ARCADE REGION]
                new Product
                {
                    Id = Guid.Parse("d577d010-4127-4ced-a937-8252158fa521"),
                    Name = "Pac-Man",
                    CategoryId = Guid.Parse("561aafdf-50fb-406b-9f95-2a2e155e9455")
                },
                new Product
                {
                    Id = Guid.Parse("8ac1d793-2a58-44fd-a2ef-7fa2a76c8f32"),
                    Name = "Mario",
                    CategoryId = Guid.Parse("561aafdf-50fb-406b-9f95-2a2e155e9455")
                }
                #endregion
            };
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetProductsByCategoryId(Guid categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public Product GetById(Guid id)
        {
            return _products.SingleOrDefault(p => p.Id == id);
        }
    }
}