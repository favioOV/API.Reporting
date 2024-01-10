using API.Domain.Entities;

namespace API.Infrastructure.Contracts
{
    public interface IPersonRepository
    {
        Task<Person?> GetPersonByIdAsync(int? id/*, CancellationToken cancellationToken*/);
        Task<IEnumerable<Person>> GetAllPersonsAsync(/*CancellationToken cancellationToken*/);
        Task SavePersonAsync(Person person, CancellationToken cancellationToken);
        Task UpdatePersonAsync(Person person, CancellationToken cancellationToken);
        Task DeletePersonAsync(int id, CancellationToken cancellationToken);
    }
}