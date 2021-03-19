using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Models.Interfaces.RepositryPattern
{
    public interface IRepository<TModel, TId>
        where TModel : IEntity<TId>
    {
        Task AddAsync(TModel obj, CancellationToken cancellationToken = default);
        Task<IEnumerable<TModel>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<TModel> GetByIdAsync(TId id, CancellationToken cancellationToken = default);
        Task UpdateAsync(TModel item,  CancellationToken cancellationToken = default);
        Task RemoveAsync(TModel item, CancellationToken cancellationToken = default);

    }

}
