using System.Collections.Generic;

namespace EF_Core_Demo.Models.DB
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}