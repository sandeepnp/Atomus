using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Atomus.Models;
using Atomus.Repositories;

namespace Atomus.Controllers
{
    public class HomeController : Controller
    {
        private IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult UploadFile()
        {
           return View();
        }

        public ActionResult UploadCsvFile()
        {
            if (Request.Files.Count == 1)
            {
                // Get the uploaded file
                HttpPostedFileBase uploadedFile = Request.Files[0];

                if (uploadedFile != null && uploadedFile.ContentLength > 0)
                {
                    // Process the uploaded file
                    if (_employeeRepository.UploadEmployees(uploadedFile))
                    {
                        // handle success
                       return Json(new { success = true });
                    }
                }
            }
            // handle failure
            return Json(new { success = false });
        }

        public ActionResult DisplayEmployees()
        {
            return View();
        }

        [HttpGet]
        public JsonResult DisplayResults()
        {
            IEnumerable<Employee> employees = _employeeRepository.GetEmployees();
            return Json(employees, JsonRequestBehavior.AllowGet);
        }
    }
}