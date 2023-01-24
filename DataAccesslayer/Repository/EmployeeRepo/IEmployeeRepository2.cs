using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesslayer.Repository.EmployeeRepo
{
    public interface IEmployeeRepository2
    {
        public void ReadingFileDataForStringReading(IFormFile file);
    }
}
