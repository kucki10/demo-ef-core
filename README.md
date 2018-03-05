# Battle plan for Demo of EF Core

## Installing EF-Core 
Install db provider: `Install-Package Microsoft.EntityFrameworkCore.SqlServer`

Install Tools: `Install-Package Microsoft.EntityFrameworkCore.Tools`

## Create our DbContext class
Create class DatabaseContext which derrives from DbContext
```csharp
using Microsoft.EntityFrameworkCore;
using EF_Core_Demo.Models.DB;

namespace EF_Core_Demo.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        //public DbSet<Ratings> Ratings { get; set; }

    }
}
```


## Create the models
Create class `Category` and `Product` ...


## Add connection string
Adjust method `ConfigureServices` of class `Startup.cs`
```csharp
var connection = @"Server=LENOVO-LUCA;Database=SampleDb;Trusted_Connection=True;ConnectRetryCount=0";
services.AddDbContext<BloggingContext>(options => options.UseSqlServer(connection));
```


## Now let's create the database
1. Open the PMC
    
    **Tools –> NuGet Package Manager –> Package Manager Console**

2. Run `Add-Migration InitialSetup`
3. Run `Update-Database` to apply the new migration to the database.

> *Q: Which connection string is used?* <br>
> A: Somehow it uses he code (Solution -> Startup Project)

>*Q: How to revert a migration?* <br>
> A: Use command `Remove-Migration` to revert the generated migrations


## Add controler to handle stuff
