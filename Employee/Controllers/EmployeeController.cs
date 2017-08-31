using Employee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employee.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            EmployeeDbContext dbContext = new EmployeeDbContext();
            List<EmployeeModels> emplist = dbContext.Employees.OrderBy(c => c.Name).ToList();
            return View(emplist);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(EmployeeModels employee)
        {
            if (ModelState.IsValid)
            {
                EmployeeDbContext dbContext = new EmployeeDbContext();
                dbContext.Employees.Add(employee);
                dbContext.SaveChanges();
                ViewBag.Message = "Saved Successfully";
                return View();
            }
            else
            {
                return View(employee);
            }

        }
    }
}