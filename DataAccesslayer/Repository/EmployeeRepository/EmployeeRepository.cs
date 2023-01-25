
using CsvHelper;
using DataAccesslayer.DataContext;
using DomainEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Globalization;


namespace DataAccesslayer.Repository.EmployeeRepository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDBContext DbContext;
        public EmployeeRepository(ApplicationDBContext _context)
        {
            DbContext = _context;
        }
        List<Employee> updateEmployeesList = new List<Employee>();
        public void ReadFileData(IFormFile File)
        {
            using (var reader = new StreamReader(File.OpenReadStream()))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {

                var csvFileRecords = csv.GetRecords<Employee>().ToList();
                List<Employee> newEmployees = new List<Employee>();

                // getting record from DB
                // we are getting ALL records from DB
                var employees = DbContext.Employees.ToList();
                foreach (var csvRecord in csvFileRecords)
                {
                    if (csvRecord is null) continue;
                    //when all employees are in memory in the list, then, why we are calling DB every time
                    var existingEmployee = DbContext.Employees.Where(x => x.EmployeeId == csvRecord.EmployeeId).SingleOrDefault(); // singleordefault
                    if (existingEmployee != null)
                    {
                        UpdateEmployee(ref existingEmployee, csvRecord);
                        updateEmployeesList.Add(existingEmployee);

                    }
                    else
                    {
                        Employee employee = new Employee();
                        AddEmployee(employee, csvRecord);
                        newEmployees.Add(employee);

                    }

                }
                foreach (var employee in employees)
                {
                    if (employee is null) continue;
                    if (!csvFileRecords.Any(x => x.EmployeeId == employee.EmployeeId))
                    {
                        DbContext.Employees.RemoveRange(employee); // RemoveRange
                    }
                }
                DbContext.Employees.AddRange(newEmployees);
                DbContext.Employees.UpdateRange(updateEmployeesList);
                DbContext.SaveChanges();
            }
        }
        private void UpdateEmployee(ref Employee existingEmployee, Employee csvRecord)
        {
            existingEmployee.FirstName = csvRecord.FirstName;
            existingEmployee.LastName = csvRecord.LastName;
            existingEmployee.JobTitle = csvRecord.JobTitle;
            existingEmployee.Email = csvRecord.Email;
            existingEmployee.MobilePhone = csvRecord.MobilePhone;
            existingEmployee.HomePhone = csvRecord.HomePhone;
            existingEmployee.EmploymentStatus = csvRecord.EmploymentStatus;
            existingEmployee.PayType = csvRecord.PayType;
            existingEmployee.Status = csvRecord.Status;
            existingEmployee.EmployeePayGroup = csvRecord.EmployeePayGroup;
            existingEmployee.HireDate = csvRecord.HireDate;
            existingEmployee.TerminationDate = csvRecord.TerminationDate;
            existingEmployee.BirthDate = csvRecord.BirthDate;
            existingEmployee.EmployeeSupervisor = csvRecord.EmployeeSupervisor;
            existingEmployee.HierarchyLevel1 = csvRecord.HierarchyLevel1;
            existingEmployee.HierarchyLevel2 = csvRecord.HierarchyLevel2;
            existingEmployee.Wage = csvRecord.Wage;

            //updaterange
        }
        private void AddEmployee(Employee employee, Employee csvRecord)

        {
            employee.EmployeeId = csvRecord.EmployeeId;
            employee.FirstName = csvRecord.FirstName;
            employee.LastName = csvRecord.LastName;
            employee.JobTitle = csvRecord.JobTitle;
            employee.Email = csvRecord.Email;
            employee.MobilePhone = csvRecord.MobilePhone;
            employee.HomePhone = csvRecord.HomePhone;
            employee.EmploymentStatus = csvRecord.EmploymentStatus;
            employee.PayType = csvRecord.PayType;
            employee.Status = csvRecord.Status;
            employee.EmployeePayGroup = csvRecord.EmployeePayGroup;
            employee.HireDate = csvRecord.HireDate;
            employee.TerminationDate = csvRecord.TerminationDate;
            employee.BirthDate = csvRecord.BirthDate;
            employee.EmployeeSupervisor = csvRecord.EmployeeSupervisor;
            employee.HierarchyLevel1 = csvRecord.HierarchyLevel1;
            employee.HierarchyLevel2 = csvRecord.HierarchyLevel2;
            employee.Wage = csvRecord.Wage;
        }

    }

}
