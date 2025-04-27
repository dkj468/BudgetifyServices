using IncomeService.Entities;
using Microsoft.EntityFrameworkCore;

namespace IncomeService.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public DbSet<Income> Incomes { get; set; }
        public DbSet<IncomeType> IncomeTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach(var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.GetTableName()?.ToLower());
            }

            modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()).ToList()
                .ForEach(p => p.SetColumnName(p.GetColumnName().ToLower()));
        }

    }
}
