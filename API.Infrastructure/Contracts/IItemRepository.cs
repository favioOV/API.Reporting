using API.Domain.Entities;

namespace API.Infrastructure.Contracts
{
    public interface IItemRepository
    {
        Task<Item?> GetItemByIdAsync(int id, CancellationToken cancellationToken);
        Task<IEnumerable<Item>> GetAllItemsAsync(CancellationToken cancellationToken);
        Task SaveItemAsync(Item Item, CancellationToken cancellationToken);
        Task UpdateItemAsync(Item Item, CancellationToken cancellationToken);
        Task DeleteItemAsync(int id, CancellationToken cancellationToken);
    }
}
