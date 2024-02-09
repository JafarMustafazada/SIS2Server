namespace SIS2Server.BLL.DTO.Common;

public interface IBaseDto<TEntity>
{
    void SetEntity(TEntity entity);
    TEntity GetEntity();
}
