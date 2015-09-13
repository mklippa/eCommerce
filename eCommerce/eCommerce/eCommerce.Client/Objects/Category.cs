using System;
using System.Collections.Generic;

namespace eCommerce.Client.Objects
{
    public class Category : BaseObject
    {
        public string Name { get; set; }
        public List<Category> SubCategories { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}