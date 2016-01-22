using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    public class TasksController : Controller
    {
        private ApplicationDbContext _context;

        public TasksController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Tasks
        public IActionResult Index()
        {
            return View(_context.Tasks.ToList());
        }

        // GET: Tasks/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Tasks tasks = _context.Tasks.Single(m => m.ID == id);
            if (tasks == null)
            {
                return HttpNotFound();
            }

            return View(tasks);
        }

        // GET: Tasks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tasks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Tasks tasks)
        {
            if (ModelState.IsValid)
            {
                _context.Tasks.Add(tasks);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tasks);
        }

        // GET: Tasks/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Tasks tasks = _context.Tasks.Single(m => m.ID == id);
            if (tasks == null)
            {
                return HttpNotFound();
            }
            return View(tasks);
        }

        // POST: Tasks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Tasks tasks)
        {
            if (ModelState.IsValid)
            {
                _context.Update(tasks);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tasks);
        }

        // GET: Tasks/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Tasks tasks = _context.Tasks.Single(m => m.ID == id);
            if (tasks == null)
            {
                return HttpNotFound();
            }

            return View(tasks);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Tasks tasks = _context.Tasks.Single(m => m.ID == id);
            _context.Tasks.Remove(tasks);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
