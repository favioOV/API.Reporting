using API.Domain.Entities;
using API.Infrastructure;
using API.Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;

namespace API.Application.Services
{
    public class ItemRepository : IItemRepository
    {
        private readonly ReportContext _context;

        public ItemRepository(ReportContext context)
        {
            _context = context;
        }

        public async Task<Item?> GetItemByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Items.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<Item>> GetAllItemsAsync(CancellationToken cancellationToken)
        {
            return await _context.Items.ToListAsync(cancellationToken);
        }

        public async Task SaveItemAsync(Item Item, CancellationToken cancellationToken)
        {
            await _context.Items.AddAsync(Item, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateItemAsync(Item Item, CancellationToken cancellationToken)
        {
            _context.Items.Update(Item);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteItemAsync(int id, CancellationToken cancellationToken)
        {
            var Item = await _context.Items.FindAsync(new object[] { id }, cancellationToken);
            if (Item != null)
            {
                _context.Items.Remove(Item);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}