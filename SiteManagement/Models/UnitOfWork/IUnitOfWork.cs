using Microsoft.EntityFrameworkCore.Storage;

namespace SiteManagement.Models.UnitOfWork
{
    public interface IUnitOfWork
    {
        int Commit();
        Task<int> CommitAsync();
        IDbContextTransaction BeginTransaction();
    }
}
