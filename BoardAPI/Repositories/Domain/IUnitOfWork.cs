using System.Threading.Tasks;

namespace BoardAPI.Repositories.Domain
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
