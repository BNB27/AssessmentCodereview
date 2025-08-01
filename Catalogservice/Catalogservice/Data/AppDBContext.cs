using Catalogservice.Models;

using Microsoft.EntityFrameworkCore;

namespace Catalogservice.Data

{

    public class AppDBContext : DbContext

    {

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)

        {

        }

        public DbSet<Catalog> CatalogServices { get; set; }
        // created to store the catalogs
    }

}



 