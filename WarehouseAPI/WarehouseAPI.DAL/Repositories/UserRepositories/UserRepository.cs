using Microsoft.EntityFrameworkCore;
using WarehouseAPI.DAL.DataAccess;
using WarehouseAPI.Domain.Entities;

namespace WarehouseAPI.DAL.Repositories.UserRepositories
{
    internal class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(WarehouseDBContext warehouseDBContext) : base(warehouseDBContext)
        {

        }

        public Task<User?> GetByLoginAsync(string login)
        {
            return DbSet.AsNoTracking().FirstOrDefaultAsync(_ => _.Login == login);
        }
    }
}
