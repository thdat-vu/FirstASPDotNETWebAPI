using DatvtFirstWebAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatvtFirstWebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
            
        }

        public DbSet<Person> Persons { get; set; }
    }
}
