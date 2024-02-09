using WarehouseAPI.Domain.Entities;

namespace WarehouseAPI.DAL.Repositories.UserRepositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetByLoginAsync(string login);
    }
}
