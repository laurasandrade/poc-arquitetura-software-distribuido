using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Logging;
using poc.pos.arquiteturasoftwaredistribuido.api.Domain.Contract.Infrastructure.Repository;
using poc.pos.arquiteturasoftwaredistribuido.api.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace poc.pos.arquiteturasoftwaredistribuido.api.Infra.Entity.Repository
{

    public abstract class BaseRepository<TContext, TEntity> : IBaseRepository<TEntity> where TEntity : class where TContext : DbContext
    {
        protected readonly DbContext context;
        protected readonly DbSet<TEntity> dbSet;
        protected readonly ILogger<BaseRepository<TContext, TEntity>> logger;

        private bool disposed;

        public BaseRepository(TContext context,
                              ILogger<BaseRepository<TContext, TEntity>> logger)
        {
            this.context = context;
            dbSet = this.context.Set<TEntity>();
            this.logger = logger;
        }

        /// <summary>
        /// Retorna o filtro da entidade requisitada.
        /// Quantidade padrão = 10.
        /// </summary>
        /// <param name="predicate">Expressão para filtro.</param>
        /// <param name="orderBy">Ordenação.</param>
        /// <param name="page">página.</param>
        /// <param name="amount">quantidate.</param>
        /// <param name="include">inclusão de filhos.</param>
        /// <returns></returns>
        public virtual async Task<BaseResponse<List<TEntity>>> FilterAsync(Expression<Func<TEntity, bool>>? predicate = null,
                                                                           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
                                                                           int? page = null,
                                                                           int? amount = null,
                                                                           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object?>>? include = null)
        {
            logger.LogInformation($"Obtendo entidade filtrada do repositório {typeof(TEntity).Name}");
            List<TEntity> result;
            var query = dbSet.AsNoTracking().AsQueryable();
            if (include != null)
            {
                query = include(query);
            }
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (orderBy != null)
            {
                result = await orderBy(query).Skip((page.HasValue ? page.Value - 1 : 0) * (amount ?? 10))
                                  .Take(amount ?? 10).ToListAsync();
            }
            else
            {
                result = await query.Skip((page.HasValue ? page.Value - 1 : 0) * (amount ?? 10))
                                      .Take(amount ?? 10).ToListAsync();
            }
            var response = new BaseResponse<List<TEntity>>() { Data = result };
            response.Total = await query.CountAsync();
            return response;
        }

        /// <summary>
        /// Retorna lista da entidade requisitada.
        /// Quantidade padrão = 10.
        /// </summary>
        /// <param name="predicate">Expressão para filtro.</param>
        /// <param name="orderBy">Ordenação.</param>
        /// <param name="include">inclusão de filhos.</param>
        /// <returns></returns>
        public virtual async Task<BaseResponse<List<TEntity>>> ListAllAsync(Expression<Func<TEntity, bool>>? predicate = null,
                                                                            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
                                                                            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object?>>? include = null)
        {
            logger.LogInformation($"Obtendo entidade filtrada do repositório {typeof(TEntity).Name}");
            List<TEntity> result;
            var query = dbSet.AsNoTracking().AsQueryable();
            if (include != null)
            {
                query = include(query);
            }
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (orderBy != null)
            {
                result = await orderBy(query).ToListAsync();
            }
            else
            {
                result = await query.ToListAsync();
            }
            var response = new BaseResponse<List<TEntity>>() { Data = result };
            response.Total = await query.CountAsync();
            return response;
        }

        public virtual async Task<BaseResponse<TEntity>> GetFirstAsync(Expression<Func<TEntity, bool>>? predicate = null,
                                                                       Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object?>>? include = null)
        {
            logger.LogInformation($"Obtendo a primeira entidade do repositório {typeof(TEntity).Name}");
            var query = dbSet.AsNoTracking().AsQueryable();
            if (include != null)
            {
                query = include(query);
            }
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            var result = await query.FirstOrDefaultAsync();
            return new BaseResponse<TEntity>() { Data = result };
        }

        public virtual async Task<BaseResponse<TEntity>> GetByIdAsync(params object[] keyValues)
        {
            logger.LogInformation($"Obtendo entidade do repositório {typeof(TEntity).Name}");
            var result = await dbSet.FindAsync(keyValues);
            return new BaseResponse<TEntity>() { Data = result };
        }

        public virtual async Task<BaseResponse<TEntity>> InsertAsync(TEntity entity)
        {
            logger.LogInformation($"Inserindo entidade do repositório {typeof(TEntity).Name}");
            dbSet.Add(entity);
            return await CommitAsync(entity);
        }

        public virtual async Task<BaseResponse<TEntity>> RemoveAsync(params object[] keyValues)
        {
            logger.LogInformation($"Removendo entidade do repositório {typeof(TEntity).Name}");
            var entity = await dbSet.FindAsync(keyValues);
            dbSet.Remove(entity);
            return await CommitAsync(entity);
        }

        public virtual async Task<BaseResponse<TEntity>> UpdateAsync(TEntity entity)
        {
            logger.LogInformation($"Atualizando entidade no repositório {typeof(TEntity).Name}");
            dbSet.Update(entity);
            return await CommitAsync(entity);
        }

        private async Task<BaseResponse<TEntity>> CommitAsync(TEntity entity)
        {
            logger.LogInformation("Realizando commit.");
            var result = await context.SaveChangesAsync();
            if (result > 0)
            {
                return new BaseResponse<TEntity>() { Data = entity };
            }
            return new BaseResponse<TEntity>() { Success = false };
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
