using API.Application.DTOs;
using API.Application.Queries;
using API.Infrastructure.Contracts;
using MediatR;

namespace API.Application.Handlers.Items
{
    public class GetAllItemsHandler : IRequestHandler<GetAllItemsQuery, IEnumerable<ItemDTO>>
    {
        private readonly IItemRepository _ItemRepository;

        public GetAllItemsHandler(IItemRepository ItemRepository)
        {
            _ItemRepository = ItemRepository;
        }

        public async Task<IEnumerable<ItemDTO>> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
        {
            var Items = await _ItemRepository.GetAllItemsAsync(cancellationToken);

            // Convertir a DTOs
            var ItemDTOs = new List<ItemDTO>();
            foreach (var Item in Items)
            {
                ItemDTOs.Add(new ItemDTO
                {
                    Id = Item.Id,
                    Nombre = Item.Nombre
                });
            }

            return ItemDTOs;
        }
    }
}
