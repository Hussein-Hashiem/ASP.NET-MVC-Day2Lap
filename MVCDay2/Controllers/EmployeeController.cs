using Microsoft.AspNetCore.Mvc;
using MVCDay2.DAL.Database;
using MVCDay2.DAL.Entities;

namespace MVCDay2.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext db;
        public EmployeeController()
        {
            db = new ApplicationDbContext();
        }
        #region Index
        public IActionResult Index()
        {
            var emps = db.Employees.ToList();
            return View(emps);
        }
        #endregion
        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            if (string.IsNullOrEmpty(emp.name))
            {
                ViewBag.errormsg = "name is required :(";
                return View(emp);
            }
            if (emp.age == 0)
            {
                ViewBag.errormsg = "age is required :(";
                return View(emp);
            }
            db.Employees.Add(emp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion
        #region Update
        [HttpGet]
        public IActionResult Update(int id)
        {
            var emp = db.Employees.Where(e => e.id == id).FirstOrDefault();
            if (emp == null)
            {
                ViewBag.errormsg = "not found :(";
                return View();
            }
            return View(emp);
        }
        [HttpPost]
        public IActionResult Update(Employee emp)
        {
            var oldemp = db.Employees.Where(e => e.id == emp.id).FirstOrDefault();
            oldemp.name = emp.name;
            oldemp.age = emp.age;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion
        public IActionResult Delete(int id)
        {
            var emp = db.Employees.Where(e => e.id == id).FirstOrDefault();
            db.Employees.Remove(emp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
