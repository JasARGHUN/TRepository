using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TRepository.Models.Repositories.IRepositories;

namespace TRepository.Models.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Item = new ItemRepository(_context);
        }

        public IItemRepository Item { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
