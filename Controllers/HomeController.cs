using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AtomusFileUpload.Models;
using AtomusFileUpload.Repositories;
using AtomusFileUpload.ViewModels;

namespace AtomusFileUpload.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult UploadFile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadFile(FormCollection form)
        {
            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    // Parse the csv 
                }
            }
            return View();
        }

        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadEmployees()
        {
            if (Request.Files.Count == 1)
            {
                // Get the uploaded file
                HttpPostedFileBase uploadedFile = Request.Files[0];

                if (uploadedFile != null && uploadedFile.ContentLength > 0)
                {
                    var employeeRepository = new EmployeeRepository();

                    // Process the uploaded file
                    if (employeeRepository.UploadEmployees(uploadedFile))
                    {
                        // handle success
                        return Redirect("~/Views/Home/Success.cshtml");
                    }
                }
            }

            // handle failure
            return Redirect("failure");
        }

        public ActionResult DisplayEmployees()
        {
            var employeesViewModel = new EmployeesViewModel();

            return View("~/Views/Home/Results.cshtml", employeesViewModel); ;
        }
    }
}