using API.Domain.Entities;
using System.Net.Http.Json;

namespace API.Application.GraphQL.Queries
{
    public class PersonQuery
    {
        private HttpClient httpClient;
        public PersonQuery(IHttpClientFactory _httpClient)
        {
            httpClient = _httpClient.CreateClient();
            httpClient.BaseAddress = new Uri("https://localhost:7056/"); // Base URL of the first microservice
        }
        public async Task<IEnumerable<Person>> GetPersons()
        {
            var response = await httpClient.GetAsync("Person");
            if (response.IsSuccessStatusCode)
            {
                var items = await response.Content.ReadFromJsonAsync<List<Person>>();
                return items;
            }
            else
            {
                throw new Exception("contacten a hernan");
            }

        }

    }
}
