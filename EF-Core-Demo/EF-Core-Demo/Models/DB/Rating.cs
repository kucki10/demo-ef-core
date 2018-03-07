using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Core_Demo.Models.DB
{
    public class Rating
    {
        public int RatingId { get; set; }

        public string Author { get; set; }

        public int StarsCount { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}