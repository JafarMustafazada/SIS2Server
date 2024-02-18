using SIS2Server.BLL.DTO.Common;
using SIS2Server.BLL.DTO.StudentDTO;
using SIS2Server.BLL.Repositories.Interfaces;
using SIS2Server.Core.Common;
using SIS2Server.Core.Entities.UserRelated;

namespace SIS2Server.BLL.Services.Implements;

public class GenericCUDService<TEntity, TRepo, TCreate>
    where TEntity : BaseEntity
    where TRepo : IGenericRepo<TEntity>
    where TCreate : IBaseDto<TEntity>
{
    public TRepo _repo { get; }

    public GenericCUDService(TRepo repo)
    {
        this._repo = repo;
    }

    public virtual async Task CreateAsync(TCreate dto)
    {
        await this._repo.CreateAsync(dto.GetEntity());
        await this._repo.SaveAsync();
    }
    public virtual async Task UpdateAsync(int id, TCreate dto)
    {
        TEntity entity = this._repo.CheckId(id, true).First();
        entity = dto.GetEntity(entity);
        await this._repo.SaveAsync();
    }
    public virtual async Task RemoveAsync(int id, bool soft = true)
    {
        TEntity entity = this._repo.CheckId(id, true).First();
        this._repo.Remove(entity, soft);
        await this._repo.SaveAsync();
    }

}
