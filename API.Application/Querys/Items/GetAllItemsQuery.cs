using API.Application.DTOs;
using MediatR;

namespace API.Application.Queries
{
    public record GetAllItemsQuery() : IRequest<IEnumerable<ItemDTO>>;
}