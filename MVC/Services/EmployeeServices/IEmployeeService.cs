namespace MVC.Repository.EmployeeRepository
{
    public interface IEmployeeRepository
    {
        public void SendFile(IFormFile file);
        public void SendFileForStringReading(IFormFile file);
    }
}
