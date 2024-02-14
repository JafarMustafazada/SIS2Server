using Microsoft.EntityFrameworkCore;
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
        => noTracking ? this.Include(this.Table.AsNoTracking(), includes) : this.Include(this.Table, includes);

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
            return await Include(query, includes).SingleOrDefaultAsync(t => t.Id == id);
        }
        return await this.Table.FindAsync(id);
    }
    public IQueryable<T> Include(IQueryable<T> query, params string[] includes)
    {
        if (includes?.Length > 0)
        {
            foreach (string include in includes)
            {
                query = query.Include(include);
            }
        }
        return query;
    }

    public void Remove(T data, bool soft = true)
    {
        if (soft)
        {
            data.IsActive = false;
            this.Table.Update(data);
        } else this.Table.Remove(data);
    }
}
