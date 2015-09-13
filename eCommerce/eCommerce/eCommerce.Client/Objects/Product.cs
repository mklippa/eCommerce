using System;

namespace eCommerce.Client.Objects
{
    public class Product : BaseObject
    {
        public string Name { get; set; }
        public string ImageSource { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public Guid CategoryId { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}