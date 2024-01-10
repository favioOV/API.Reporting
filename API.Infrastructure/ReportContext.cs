using API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Infrastructure
{
    public class ReportContext : DbContext
    {
        public ReportContext(DbContextOptions<ReportContext> options) : base(options){}

        public DbSet<Item> Items { get; set; }
        public DbSet<Person> Persons { get; set; }
    }
}
