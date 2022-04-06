using MS.Postman.Domain.NerdNap;
using System.Text.Json;

namespace MS.Postman.Service.NerdNap
{
    public class EmployeeService : IMockService
    {
        JsonSerializerOptions serializerOptions = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true};
        const string URL_MOCK = "https://38990c46-afca-4cd8-beca-5e78171631e7.mock.pstmn.io/";
        const string URL_PRIVATE_MOCK = "https://1789ca04-718b-4025-9c32-67c54c5065ad.mock.pstmn.io/";
        public async Task<Employee> GetMock()
        {
            using(HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(URL_MOCK + "employee");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var employee = JsonSerializer.Deserialize<Employee>(content, serializerOptions);
                    return employee;
                }
            }
            return null;
        }

        public async Task<Employee> GetMock(string apiKey)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("x-api-key", apiKey);
                
                var response = await client.GetAsync(URL_PRIVATE_MOCK + "employee");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var employee = JsonSerializer.Deserialize<Employee>(content, serializerOptions);
                    return employee;
                }
            }
            return null;
        }
    }
}