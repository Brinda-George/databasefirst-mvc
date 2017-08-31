using EmployeeMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeMvc.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            var Department = new List<SelectListItem>
           {
               new SelectListItem
               {
                   Text="ME",
                   Value="1"
               },
               new SelectListItem
               {
                   Text="EC",
                   Value="2"
               },
               new SelectListItem
               {
                   Text="CS",
                   Value="3"
               }

           };
            ViewBag.Department = Department;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            EmployeeDbEntities DbContext = new EmployeeDbEntities();
            DbContext.Employees.Add(emp);
            DbContext.SaveChanges();
            return Json(new { message = "Save Succesfully" }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Details()
        {
            EmployeeDbEntities DbContext = new EmployeeDbEntities();

            return View(DbContext.Employees.ToList());


        }

        public ActionResult Display()
        {
            EmployeeDbEntities DbContext = new EmployeeDbEntities();
            return View(DbContext.Employees.ToList());
        }

        public ActionResult Edit(int Id)
        {
            EmployeeDbEntities DbContext = new EmployeeDbEntities();
            //Employee employee = DbContext.Employees.Where(c => c.EmpId == Id).FirstOrDefault();
            Employee employee = new Employee();
            employee = DbContext.Employees.Find(Id);

            return View(employee);
        }
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            EmployeeDbEntities DbContext = new EmployeeDbEntities();
            var emp = (from c in DbContext.Employees where c.EmpId == employee.EmpId select c).FirstOrDefault();
            emp.Name = employee.Name;
            DbContext.SaveChanges();
            return RedirectToAction("Details", "Employee");
        }

        public ActionResult Delete(int Id)
        {
            try
            {
                EmployeeDbEntities DbContext = new EmployeeDbEntities();
                // Employee employee = new Employee();

                // employee = DbContext.Employees.Find(Id);
                Employee employee = DbContext.Employees.Where(c => c.EmpId == Id).FirstOrDefault();
                DbContext.Employees.Remove(employee);
                DbContext.SaveChanges();
                return RedirectToAction("Details", "Employee");
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
    }
}




