using System.Threading.Tasks;

namespace TRepository.Models.Repositories.IRepositories
{
    public interface IItemRepository : IRepository<Item>
    {
        Task UpdateAsync(Item model);
    }
}
