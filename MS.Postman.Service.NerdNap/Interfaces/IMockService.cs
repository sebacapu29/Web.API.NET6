using MS.Postman.Domain.NerdNap;

namespace MS.Postman.Service.NerdNap
{
    public interface IMockService
    {
        Task<Employee> GetMock();
        Task<Employee> GetMock(string apiKey);
    }
}
