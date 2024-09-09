using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_Senwell.Models;
using Task_Senwell.Services;

namespace Task_Senwell.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeServices service;
        public EmployeeController(IEmployeeServices service)
        {
            this.service = service;
        }
        // GET: EmployeeController
        public ActionResult Index()
        {
            return View(service.GetAllEmployee());
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            var model = service.GetEmployeeById(id);
            return View(model);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            try
            {
                int result = service.AddEmployee(employee);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }

            }
            catch (Exception ex)
            {
                return View();  // remain on Create page.
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = service.GetEmployeeById(id);
            return View(model);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            try
            {
                int result = service.UpdateEmployee(employee);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }

            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = service.DeleteEmployee(id);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }

            }
            catch
            {
                return View();
            }
        }
    }
}
