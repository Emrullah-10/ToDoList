using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class ToDoController : Controller
    {
        private readonly AppDbContext _db;
        public ToDoController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null) return RedirectToAction("Login", "Account");

            var todos = _db.ToDoItems.Where(t => t.UserId == userId).ToList();
            return View(todos);
        }

        [HttpPost]
        public IActionResult Add(string title)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null) return RedirectToAction("Login", "Account");

            var todo = new ToDoItem { Title = title, UserId = userId.Value };
            _db.ToDoItems.Add(todo);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Toggle(int id)
        {
            var todo = _db.ToDoItems.Find(id);
            if (todo != null)
            {
                todo.IsCompleted = !todo.IsCompleted;
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var todo = _db.ToDoItems.Find(id);
            if (todo != null)
            {
                _db.ToDoItems.Remove(todo);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
