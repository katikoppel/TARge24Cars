
using Cars.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Cars.Data
{
    public class CarsContext : DbContext
    {
        public CarsContext(DbContextOptions<CarsContext> options)
            : base(options) { }

        public DbSet<Car> Cars { get; set; }

    }
}
