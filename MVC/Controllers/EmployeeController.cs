using Microsoft.AspNetCore.Mvc;
using MVC.Repository.EmployeeRepository;

namespace MVC.Controllers
{
    public class EmployeeController : Controller
    {
        HttpClient httpClient = new HttpClient();
        private readonly  IEmployeeRepository employeeRepository;
        public EmployeeController(IEmployeeRepository _employee)
        {
            employeeRepository = _employee;
          
        }
        [HttpGet]
        public IActionResult UploadFile()
        {
            return View ();
        }
        [HttpPost]
        public IActionResult UploadFile(IFormFile myfile)
        {

            employeeRepository.SendFile(myfile);

            return Ok();
        }

        [HttpGet]
        public IActionResult UploadFileAsString()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UploadFileAsString(IFormFile myfile)
        {

            employeeRepository.SendFileForStringReading(myfile);

            return Ok();
        }
    }
}
