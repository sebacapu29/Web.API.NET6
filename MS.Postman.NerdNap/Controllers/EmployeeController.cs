using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MS.Postman.Domain.NerdNap;
using MS.Postman.Service.NerdNap;

namespace MS.Postman.NerdNap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMockService _mockService;
        private readonly ILogger<EmployeeController> _logger;
        public EmployeeController(IMockService mockService, ILogger<EmployeeController> logger)
        {
            _mockService = mockService;
            _logger = logger;
        }
        [HttpGet("/GetMock")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Employee))]
        public async Task<IActionResult> GetEmployee()
        {
            var employeeMock = await _mockService.GetMock();
            
            if (employeeMock == null)
                return NotFound(new { Response = "No se encontro el empleado" });

            return Ok(employeeMock);
        }
        [HttpGet("/GetMockAuth")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Employee))]
        public async Task<IActionResult> GetEmployeeAuth(int idEmployee)
        {
            HttpContext.Request.Headers.TryGetValue("x-api-key", out var apiKey);

            var employeeMock = await _mockService.GetMock(apiKey);

            if (employeeMock == null)
                return NotFound(new { Response = "No se encontro el empleado" });

            return Ok(employeeMock);
        }
    }
}
