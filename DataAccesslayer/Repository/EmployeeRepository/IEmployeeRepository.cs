using DomainEntities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesslayer.Repository.EmployeeRepository
{
    public interface IEmployeeRepository
    {
        public void ReadFileData(IFormFile File);
      
    }
}
