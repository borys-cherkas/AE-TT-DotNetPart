using Microsoft.EntityFrameworkCore;
using TransactionalSystem.Data.Entities;

namespace TransactionalSystem.DataAccess
{
    public class TransactionsDbContext : DbContext
    {
        public TransactionsDbContext(DbContextOptions<TransactionsDbContext> dbContextOptions)
            : base(dbContextOptions) { }

        internal DbSet<TransactionEntity> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TransactionEntity>()
                .HasKey(x => x.Id);
        }
    }
}
