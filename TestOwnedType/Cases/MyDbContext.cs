using Microsoft.EntityFrameworkCore;

namespace TestOwnedType.Cases
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MyEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentRecordEntityConfiguration());

        }

        public DbSet<MyEntity> MyEntities { get; set; }
        public DbSet<PaymentRecordEntity> PaymentRecords { get; set; }
    }
}
