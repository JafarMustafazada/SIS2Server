using Microsoft.EntityFrameworkCore;
using SIS2Server.BLL.Exceptions.Common;
using SIS2Server.BLL.Extensions;
using SIS2Server.BLL.Repositories.Interfaces;
using SIS2Server.Core.Common;
using SIS2Server.DAL.Contexts;
using System.Linq.Expressions;

namespace SIS2Server.BLL.Repositories.Implements;

public class GenericRepo<T> : IGenericRepo<T> where T : BaseEntity
{
    SIS02DbContext _context { get; }

    public GenericRepo(SIS02DbContext context)
    {
        this._context = context;
    }

    public DbSet<T> Table => this._context.Set<T>();

    // //
    public IQueryable<T> GetAll(bool noTracking = true, params string[] includes)
        => noTracking ? this.Table.AsNoTracking().Includes(includes) : this.Table.Includes(includes);

    public async Task<bool> IsExistAsync(Expression<Func<T, bool>> expression)
    {
        return await this.Table.AnyAsync(expression);
    }

    public async Task CreateAsync(T data)
    {
        await this.Table.AddAsync(data);
    }

    public async Task SaveAsync()
    {
        await this._context.SaveChangesAsync();
    }

    public async Task<T> GetByIdAsync(int id, bool noTracking = true, params string[] includes)
    {
        if (noTracking || includes != null)
        {
            IQueryable<T> query = noTracking ? this.Table.AsNoTracking() : this.Table;
            return await query.Includes(includes).SingleOrDefaultAsync(t => t.Id == id);
        }
        return await this.Table.FindAsync(id);
    }

    public void Remove(T data, bool soft = true)
    {
        if (soft)
        {
            data.IsActive = !data.IsActive;
            this.Table.Update(data);
        } else this.Table.Remove(data);
    }

    /// <summary>
    /// Checks if there is only one entity with given id.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="isTrack"></param>
    /// <returns>Querry of single entity with given id. Can be used with method "First()".</returns>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="NotFoundException{T}"></exception>
    /// <exception cref="ManySameKeyException{T}"></exception>
    public IQueryable<T> CheckId(int id, bool isTrack = false)
    {
        if (id <= 0) throw new ArgumentException();

        IQueryable<T> data = isTrack 
            ? this.Table.Where(x => x.Id == id).Take(2) 
            : this.Table.Where(x => x.Id == id).AsNoTracking().Take(2);

        return data.Count() switch
        {
            0 => throw new NotFoundException<T>(),
            1 => data,
            _ => throw new ManySameKeyException<T>(),
        };
    }
}
