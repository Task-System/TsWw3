using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace TsWw3TelegramBot.Databases
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        TsWw3Context Context { get; }
        DbSet<TEntity> DbSet { get; }
        void Delete(TEntity entityToDelete);
        Task DeleteAsync(object id);
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, string includeProperties = "");
        Task<TEntity?> GetByIDAsync(object id);
        void Insert(TEntity entity);
        void Update(TEntity entityToUpdate);
    }
}