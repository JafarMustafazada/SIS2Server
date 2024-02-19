using SIS2Server.BLL.DTO.Common;
using SIS2Server.BLL.Repositories.Interfaces;
using SIS2Server.Core.Common;

namespace SIS2Server.BLL.Services.Implements;

public class GenericCUDService<TEntity, TRepo, TCreate>(TRepo repo)
    where TEntity : BaseEntity
    where TRepo : IGenericRepo<TEntity>
    where TCreate : IBaseDto<TEntity>
{
    public virtual async Task CreateAsync(TCreate dto)
    {
        await repo.CreateAsync(dto.GetEntity());
        await repo.SaveAsync();
    }
    public virtual async Task UpdateAsync(int id, TCreate dto)
    {
        TEntity entity = repo.CheckId(id, true).First();
        entity = dto.GetEntity(entity);
        await repo.SaveAsync();
    }
    public virtual async Task RemoveAsync(int id, bool soft = true)
    {
        TEntity entity = repo.CheckId(id, true).First();
        repo.Remove(entity, soft);
        await repo.SaveAsync();
    }
}
