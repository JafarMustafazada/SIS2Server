using Microsoft.EntityFrameworkCore;
using SIS2Server.Core.Common;
using System.Linq.Expressions;

namespace SIS2Server.BLL.Repositories.Interfaces;

public interface IGenericRepo<T> where T : BaseEntity
{
    DbSet<T> Table { get; }
    IQueryable<T> GetAll(bool noTracking = true, params string[] includes);
    Task<T> GetByIdAsync(int id, bool noTracking = true, params string[] includes);
    Task<bool> IsExistAsync(Expression<Func<T, bool>> expression);
    Task CreateAsync(T data);
    void Remove(T data, bool soft = true);
    Task SaveAsync();
}
