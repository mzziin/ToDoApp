using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Todo.DataAccess.Data;
using Todo.Models;

namespace Todo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Tasks> TaskList = _db.Tasks.ToList();
            return View(TaskList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Tasks obj)
        {
            if (ModelState.IsValid)
            {
                _db.Tasks.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "New Task Created";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Something went wrong";
            return View();
        }

        public IActionResult CompleteTask(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Tasks? obj = _db.Tasks.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Tasks.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Task completed successfully";
            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
