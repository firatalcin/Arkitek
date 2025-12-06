namespace Arkitek.DataAccess.UOW
{
    public interface IUnitOfWork
    {
        Task<bool> SaveChangesAsync();
    }
}
