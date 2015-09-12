using System;
using System.Collections.Generic;

namespace eCommerce.Core.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Category> SubCategories { get; set; }
    }
}