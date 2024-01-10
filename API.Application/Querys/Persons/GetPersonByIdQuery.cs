using API.Application.DTOs;
using MediatR;

namespace API.Application.Querys.Person
{
    public record GetPersonByIdQuery(int id) : IRequest<PersonDTO>;

}