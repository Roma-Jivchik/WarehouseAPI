using Microsoft.EntityFrameworkCore;
using WarehouseAPI.DAL.DataAccess;
using WarehouseAPI.Domain.Entities;

namespace WarehouseAPI.DAL.Repositories.WorkerRepositories
{
    internal class WorkerRepository : BaseRepository<Worker>, IWorkerRepository
    {
        public WorkerRepository(WarehouseDBContext warehouseDBContext) : base(warehouseDBContext) 
        {

        }

        public Task<Worker?> GetByLastNameAsync(string lastName)
        {
            return DbSet.AsNoTracking().FirstOrDefaultAsync(_ => _.LastName == lastName);
        }

        public Task<List<Worker>> GetByPosition(string position)
        {
            return DbSet.AsNoTracking()
                .Where(_ => _.Position == position)
                .OrderBy(_ => _.LastName)
                .ToListAsync();
        }
    }
}
