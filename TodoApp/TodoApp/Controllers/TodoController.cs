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

        public ActionResult Create(string Name)
        {
            if (!string.IsNullOrEmpty(Name))
            {
                // adatok mentése és vissza az indexre
                MyDb.Lista.Add(new TodoItem() { Name = Name, Done = true });
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}