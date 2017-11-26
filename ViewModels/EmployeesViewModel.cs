using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AtomusFileUpload.Models;
using AtomusFileUpload.Repositories;

namespace AtomusFileUpload.ViewModels
{
    public class EmployeesViewModel
    {
        [Display(Name = "Employee List")]
        public string PageName { get; set; }

        [Display(Name = "No employees were found")]
        public string NoResults { get; set; }

        public IEnumerable<Employee> Employees { get; set; }

        public EmployeesViewModel()
        {
            EmployeeRepository employeeRepository = new EmployeeRepository();
            Employees = employeeRepository.GetEmployees();
        }
    }
}