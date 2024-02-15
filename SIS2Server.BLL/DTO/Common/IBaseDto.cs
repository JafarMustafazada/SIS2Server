using Microsoft.EntityFrameworkCore;

namespace SIS2Server.BLL.DTO.Common;

public interface IBaseDto<TEntity> where TEntity : class
{
    public bool HasGetter 
    { 
        get
        {
            try
            {
                this.GetEntity();
            }
            catch (NotImplementedException)
            {
                return false;
            }
            return true;
        }
    }

    TEntity GetEntity(DbSet<TEntity> table = null);
}
