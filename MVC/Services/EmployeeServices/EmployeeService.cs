using Newtonsoft.Json;
using RestSharp;
using System.Net.Http;
using System.Text;

namespace MVC.Repository.EmployeeRepository
{
    public class EmployeeRepository:IEmployeeRepository
    {
        public EmployeeRepository()
        {
        }
        public void SendFile(IFormFile file)
        {
           
            RestClient client = new RestClient("https://localhost:7204/api/Employee/ReadFileData");
            //call the SendRequest method for calling api 
            SendRequest(file,client);
        }

        public void SendFileForStringReading(IFormFile file)
        {
            
            RestClient client = new RestClient("https://localhost:7204/api/Employee/ReadFileDataAsString");
            //call the SendRequest method for calling api 
            SendRequest(file,client);
        }
        private void SendRequest(IFormFile file,RestClient client)
        {
            try
            {
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddFile("file", @"E:\csv\test.csv");
                IRestResponse response = client.Execute(request);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
