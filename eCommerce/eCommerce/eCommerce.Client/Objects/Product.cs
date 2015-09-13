using System;

namespace eCommerce.Client.Objects
{
    public class Product : BaseObject
    {
        public string Name { get; set; }
        public Guid CategoryId { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}