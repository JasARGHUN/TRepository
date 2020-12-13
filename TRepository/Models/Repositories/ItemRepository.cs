using System.Threading.Tasks;
using TRepository.Models.Repositories.IRepositories;

namespace TRepository.Models.Repositories
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        private readonly ApplicationDbContext _context;

        public ItemRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task UpdateAsync(Item model)
        {
            _context.Items.Update(model);
            await _context.SaveChangesAsync();
        }
    }
}
