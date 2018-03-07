using System.Linq;
using EF_Core_Demo.Models.DB;

namespace EF_Core_Demo.Models
{
    public static class DataInitializer
    {
        public static void Init(DatabaseContext dbContext)
        {
            //Now create some categories
            if (dbContext.Categories.Any())
            {
                //DB has been seeded already
                return;
            }


            //Generate Categories
            var categories = new Category[]
            {
                new Category {Name = "Sports"},
                new Category {Name = "Games"},
                new Category {Name = "Category without products"},
                new Category {Name = "Clothes"}
            };

            foreach (var c in categories)
            {
                dbContext.Categories.Add(c);
            }
            dbContext.SaveChanges(); //CAUTION: Might throw DbUpdateException


            var categorySports = dbContext.Categories.First(c => c.Name == "Sports");
            var categoryGames = dbContext.Categories.First(c => c.Name == "Games");
            var categoryWithoutProducts = dbContext.Categories.First(c => c.Name == "Category without products"); //Should not be used
            var categoryClothes = dbContext.Categories.First(c => c.Name == "Clothes");
            //Generate Products
            var products = new Product[]
            {
                new Product {Name = "Football ball", Description = "bla bla ...", CategoryId = categorySports.CategoryId},
                new Product {Name = "Baseball ball", Description = "bla bla ...", CategoryId = categorySports.CategoryId},
                new Product {Name = "Football shoes", Description = "bla bla ...", CategoryId = categorySports.CategoryId},
                new Product {Name = "Football shirt", Description = "bla bla ...", CategoryId = categorySports.CategoryId},
                new Product {Name = "Tennis ball", Description = "bla bla ...", CategoryId = categorySports.CategoryId},

                new Product {Name = "Mario Kart", Description = "bla bla ...", CategoryId = categoryGames.CategoryId},
                new Product {Name = "Super Mario Smash Bros", Description = "bla bla ...", CategoryId = categoryGames.CategoryId},
                new Product {Name = "Legend of Zelda", Description = "bla bla ...", CategoryId = categoryGames.CategoryId},

                //DO not add a product in category categoryWithoutProducts.CategoryId

                new Product {Name = "Jeans", Description = "", CategoryId = categorySports.CategoryId},
                new Product {Name = "Troussers", Description = "", CategoryId = categoryClothes.CategoryId},
                new Product {Name = "Shoes", Description = "", CategoryId = categoryClothes.CategoryId},
                new Product {Name = "Cap", Description = "", CategoryId = categoryClothes.CategoryId}
            };

            foreach (var p in products)
            {
                dbContext.Products.Add(p);
            }

            dbContext.SaveChanges(); //CAUTION: Might throw DbUpdateException


            /*

            var productMarioKart = dbContext.Products.First(c => c.Name == "Mario Kart");
            var productFootbalBall = dbContext.Products.First(c => c.Name == "Football ball");
            //Generate Rating
            var ratings = new Rating[]
            {
                new Rating {Author = "Mario-Fanboy", StarsCount = 5, ProductId = productMarioKart.ProductId},
                new Rating {Author = "Luigi", StarsCount = 4, ProductId = productMarioKart.ProductId},

                new Rating {Author = "Tom Brady", StarsCount = 5, ProductId = productFootbalBall.ProductId},
                new Rating {Author = "NoCatcher", StarsCount = 2, ProductId = productFootbalBall.ProductId},
            };

            foreach (var r in ratings)
            {
                dbContext.Ratings.Add(r);
            }

            dbContext.SaveChanges(); //CAUTION: Might throw DbUpdateException

            */
        }
    }
}