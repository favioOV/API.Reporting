using API.Application.DTOs;
using API.Application.Querys;
using API.Infrastructure.Contracts;
using MediatR;

namespace API.Application.Handlers.Items
{
    public class GetItemByIdHandler : IRequestHandler<GetItemByIdQuery, ItemDTO>
    {
        private readonly IItemRepository _ItemRepository;

        public GetItemByIdHandler(IItemRepository ItemRepository)
        {
            _ItemRepository = ItemRepository;
        }

        public async Task<ItemDTO> Handle(GetItemByIdQuery request, CancellationToken cancellationToken)
        {
            var Item = await _ItemRepository.GetItemByIdAsync(request.id, cancellationToken);

            if (Item == null)
            {
                return null;
            }

            return new ItemDTO
            {
                Id = Item.Id,
                Nombre = Item.Nombre
            };
        }
    }
}
