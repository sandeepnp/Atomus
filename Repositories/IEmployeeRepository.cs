using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Atomus.Models;

namespace Atomus.Repositories
{
    public interface IEmployeeRepository
    {
        bool UploadEmployees(HttpPostedFileBase file);

        bool AddEmployee(Employee employee);

        IEnumerable<Employee> GetEmployees();
    }
}
