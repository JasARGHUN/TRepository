using System;
using System.Threading.Tasks;

namespace TRepository.Models.Repositories.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IItemRepository Item { get; }
        Task SaveAsync();
    }
}
