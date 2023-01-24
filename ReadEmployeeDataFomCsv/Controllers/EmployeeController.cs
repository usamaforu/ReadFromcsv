using DataAccesslayer.Repository.EmployeeRepo;
using DataAccesslayer.Repository.EmployeeRepository;
using Microsoft.AspNetCore.Mvc;

namespace ReadEmployeeDataFomCsv.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository repository;
        private readonly IEmployeeRepository2 repository2;

        public EmployeeController(IEmployeeRepository _repository,IEmployeeRepository2 _employeeRepository2)
        {
            repository = _repository;
            repository2 = _employeeRepository2;
        }
        [HttpPost("ReadFileData")]
        public ActionResult ReadFileData(IFormFile file)
        {
            repository.ReadFileData(file);
            return Ok();
        }
        [HttpPost("ReadFileDataAsString")]
        public ActionResult ReadFileDataForStringReading(IFormFile file)
        {
            repository2.ReadingFileDataForStringReading(file);
            return Ok();
        }
    }
}
