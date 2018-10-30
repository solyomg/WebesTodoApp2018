using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    public class TodoController : Controller
    {
        
    // GET: TodoList
    public ActionResult Index()
        {
           return View(MyDb.Lista);
        }

        [HttpGet] // csak a GET kérésekre válaszol
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost] // csak a POST kérésekre válaszol
        public ActionResult Create(string name, bool isDone )
        {
            if (!string.IsNullOrEmpty(name))
            {
                // adatok mentése és vissza az indexre
                MyDb.Lista.Add(new TodoItem() { Name = name, Done = isDone });
                return RedirectToAction("Index");
            }
            //todo: mivel az adat nem valid, ezért ide hibaüzenet kellene

            return View();
        }
    }
}