using API.Application.DTOs;
using API.Application.Querys.Person;
using API.Infrastructure.Contracts;
using MediatR;

namespace API.Application.Handlers.Persons
{
    public class GetAllPersonsHandler : IRequestHandler<GetAllPersonsQuery, IEnumerable<PersonDTO>>
    {
        private readonly IPersonRepository _personRepository;

        public GetAllPersonsHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<IEnumerable<PersonDTO>> Handle(GetAllPersonsQuery request, CancellationToken cancellationToken)
        {
            var persons = await _personRepository.GetAllPersonsAsync(/*cancellationToken*/);

            // Convertir a DTOs
            var personDTOs = new List<PersonDTO>();
            foreach (var person in persons)
            {
                personDTOs.Add(new PersonDTO
                {
                    Id = person.Id,
                    Name = person.Name,
                    LastName = person.LastName
                });
            }

            return personDTOs;
        }
    }
}
