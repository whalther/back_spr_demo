using Employees.DataAccess.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Employees.DataAccess.Models
{
    public class MyDbContext: DbContext
    {
        private readonly string cadenaDeConexion;
        private readonly IConfiguration _configuration;
        public MyDbContext(IConfiguration Configuration)
        {
            _configuration = Configuration;
            cadenaDeConexion = _configuration["ConnectionString"];
        }
        public MyDbContext(DbContextOptions<MyDbContext> options): base(options){}
        public DbSet<employee_tbl> employee { get; set; }
        public DbSet<area_tbl> area { get; set; }
        public DbSet<subarea_tbl> subarea { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(cadenaDeConexion);
        }
    }
}
