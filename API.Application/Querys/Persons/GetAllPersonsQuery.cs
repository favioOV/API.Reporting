using API.Application.DTOs;
using MediatR;

namespace API.Application.Querys.Person
{
    public record GetAllPersonsQuery() : IRequest<IEnumerable<PersonDTO>>;
}