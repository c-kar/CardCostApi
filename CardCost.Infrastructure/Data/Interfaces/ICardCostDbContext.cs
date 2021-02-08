using CardCost.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace CardCost.Infrastructure.Data.Interfaces
{
    public interface ICardCostDbContext : IDisposable
    {
        DbSet<AccessUser> AccessUser { get; set; }
        DbSet<Ccmatrix> Ccmatrix { get; set; }
        DbSet<Iinlist> Iinlist { get; set; }
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        EntityEntry Entry([NotNullAttribute] object entity);
    }
}
