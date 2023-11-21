using System.Linq.Expressions;

namespace EstoqueApi.Infra.Repositorio
{
	public interface IRepositorioGenerico<TEntity> where TEntity : class
	{
		ValueTask<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
		void Update(TEntity entity);
		void Delete(TEntity entity);
		ValueTask<TEntity> GetByKeysAsync(CancellationToken cancellationToken = default, params object[] keys);

		IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
			string includeProperties = "",
			bool noTracking = false, int? take = null, int? skip = null);

		Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
			string includeProperties = "",
			bool noTracking = false, int? take = null, int? skip = null,
			CancellationToken cancellationToken = default);
		Task<bool> CommitAsync(CancellationToken cancellationToken = default);
	}
}
