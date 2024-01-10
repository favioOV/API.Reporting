using API.Application.Commands.Person;
using API.Application.DTOs;
using API.Infrastructure.Contracts;
using API.Domain.Entities;

using MediatR;

namespace API.Application.Handlers.Persons
{
    public class CreatePersonHandler : IRequestHandler<CreatePersonCommand, PersonDTO>
    {
        private readonly IPersonRepository _personRepository;

        public CreatePersonHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<PersonDTO> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = new Person
            {
                Name = request.Name,
                LastName = request.LastName,
                Address = request.Address,
                Age = request.Age,
            };

            await _personRepository.SavePersonAsync(person, cancellationToken);

            return new PersonDTO
            {
                Id = person.Id,
                Name = person.Name,
                LastName = person.LastName,
                Address = person.Address,
                Age= person.Age,
            };
        }
    }
}
