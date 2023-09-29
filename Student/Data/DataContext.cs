using Microsoft.EntityFrameworkCore;
using Student.Controllers;

namespace Student.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }

        //public const string ConnectString = "";

    }
}
