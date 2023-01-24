using CsvHelper;
using DataAccesslayer.DataContext;
using DomainEntities;
using Findd.Api.Busi;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesslayer.Repository.EmployeeRepo
{
    public class EmployeeRepository2 : IEmployeeRepository2
    {

        private readonly ApplicationDBContext DbContext;
        public EmployeeRepository2(ApplicationDBContext _context)
        {
            DbContext = _context;
        }

        public void ReadingFileDataForStringReading(IFormFile file)
        {

            {
                
                var filePath = @"E:\csv\Test.csv";
                CSVReader csv = new CSVReader(filePath);

                List<List<string>> fileData = new List<List<string>>();
                List<Employee2> employees =new List<Employee2>();

                try
                {
                   
                   
                    //use the csvreader to read in the csv data
                    List<string> fields;
                    while ((fields = csv.GetCSVLine()) != null)
                    {
                        List<string> rowData = new List<string>();


                        foreach (var colomData in fields)
                        {
                            if(colomData.Trim().Length != 0)
                            
                                rowData.Add(colomData);
                            else
                                rowData.Add(string.Empty);

                        }
                        fileData.Add(rowData);
                    }

                    foreach(var colomRecord in fileData)
                    {
                        var employeeRecord=AddEmployee(colomRecord);
                        employees.Add(employeeRecord);

                    }

                }
                catch (Exception ex)
                {
                    throw;
                }
                DbContext.Employee2s.AddRange(employees);
                DbContext.SaveChanges();
               
            }
           

        }
        private Employee2 AddEmployee(List<String> colomRecord)
        {

            var hireDateCheck = DateTime.TryParse(colomRecord[18], out var hireDate);
            var terminationDateCheck = DateTime.TryParse(colomRecord[21], out var termDate);
            var birthDateCheck = DateTime.TryParse(colomRecord[23], out var birthDate);
            Employee2 csvEmployee = new Employee2()
            {
                Id = Guid.NewGuid().ToString(),
                ClockPin = String.IsNullOrWhiteSpace(colomRecord[0]) ? string.Empty : colomRecord[0],
                ExternalId = String.IsNullOrWhiteSpace(colomRecord[0]) ? string.Empty : colomRecord[0],
                FirstName = String.IsNullOrWhiteSpace(colomRecord[2]) ? String.Empty : colomRecord[2],
                LastName = String.IsNullOrWhiteSpace(colomRecord[3]) ? String.Empty : colomRecord[3],
                Email = String.IsNullOrWhiteSpace(colomRecord[6]) ? String.Empty : colomRecord[6],
                HireDate = hireDateCheck ? hireDate : null,
                TerminationDate = terminationDateCheck ? termDate : null,
                DateOfBirth = birthDateCheck ? birthDate : null,

            };
            return csvEmployee;
        }
        public void sum()
        {

        }
    }
}
