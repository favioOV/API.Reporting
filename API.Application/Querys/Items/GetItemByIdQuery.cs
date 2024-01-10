using API.Application.DTOs;
using MediatR;

namespace API.Application.Querys
{
    public record GetItemByIdQuery (int id) : IRequest<ItemDTO>;

}