using API.Application.DTOs;
using MediatR;

namespace API.Application.Commands.Person
{
    public record UpdatePersonCommand(int Id, string Name, string LastName) : IRequest<PersonDTO>;
}
