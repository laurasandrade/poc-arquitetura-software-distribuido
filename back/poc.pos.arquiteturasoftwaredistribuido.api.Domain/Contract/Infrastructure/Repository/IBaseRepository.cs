using Microsoft.EntityFrameworkCore.Query;
using poc.pos.arquiteturasoftwaredistribuido.api.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace poc.pos.arquiteturasoftwaredistribuido.api.Domain.Contract.Infrastructure.Repository
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        Task<BaseResponse<TEntity>> InsertAsync(TEntity entity);
        Task<BaseResponse<TEntity>> UpdateAsync(TEntity entity);
        Task<BaseResponse<TEntity>> RemoveAsync(params object[] keyValues);
        Task<BaseResponse<TEntity>> GetByIdAsync(params object[] keyValues);
        Task<BaseResponse<TEntity>> GetFirstAsync(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object?>>? include = null);
        Task<BaseResponse<List<TEntity>>> FilterAsync(Expression<Func<TEntity, bool>>? predicate = null,
                                                      Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
                                                      int? page = null,
                                                      int? amount = null,
                                                      Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object?>>? include = null);
        Task<BaseResponse<List<TEntity>>> ListAllAsync(Expression<Func<TEntity, bool>>? predicate = null,
                                                       Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
                                                       Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object?>>? include = null);
    }
}
