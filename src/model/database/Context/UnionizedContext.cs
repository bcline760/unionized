using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Unionized.Model.Database.Context
{
    public class UnionizedContext:DbContext
    {
        public virtual DbSet<NetworkLogModel> NetworkLogs { get; set; }
        public virtual DbSet<UserTokenModel> UserTokens { get; set; }
        public UnionizedContext(DbContextOptions<UnionizedContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        public new void Add<TEntity>(TEntity entity)
            where TEntity : class
        {
            base.Add<TEntity>(entity);
        }

        public new async Task AddAsync(object entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            await base.AddAsync(entity, cancellationToken);
        }

        public new async Task<TEntity> AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
            where TEntity : class
        {
            EntityEntry<TEntity> entityEntry = await base.AddAsync<TEntity>(entity, cancellationToken);

            return entityEntry.Entity;
        }
    }
}
