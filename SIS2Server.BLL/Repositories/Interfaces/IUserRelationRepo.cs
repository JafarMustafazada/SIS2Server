namespace SIS2Server.BLL.Repositories.Interfaces;

public interface IUserRelationRepo
{
    Task AddToUser(int entityId, string userId);
}
