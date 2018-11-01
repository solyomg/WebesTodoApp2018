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
        Db db = new Db();

        // GET: TodoList
        public ActionResult Index()
        {
           return View(db.TodoItems.ToList());
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
                db.TodoItems.Add(new TodoItem() { Name = name, Done = isDone });
                //adatbázisba írni
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //todo: mivel az adat nem valid, ezért ide hibaüzenet kellene

            return View();
        }

        /// <summary>
        /// Az action feladata az adott elem megjelenítése módosításra.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(int id)
        {
            //elő kell keresni az adott elemet
            //MyDb.Lista.Where(x => x.Id == Id); // ez lesz aegy olyan LISTA, amin csak a feltételnek megfelelő elemek vannak

            // ha tudom hogy pontosan egy elemet keresek
            //ezt akkor tudom használni, ha garantálni tudom, hogy ez igaz.
            var item = db.TodoItems.Single(x => x.Id == id);

            //ha nem tudom garantálni, akkor
            //ha van ilyen elem, akkor azt adja vissza,
            //ha nincs, akkor nullát ad
            //var item = MyDb.Lista.SingleorDefault(x => x.Id == id);

            //ezt az elemet kell módosítanom

            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(int id, string name, bool done)
        {
            //elem kikeresése
            var item = db.TodoItems.Single(x => x.Id == id);
            // módosítás
            item.Name = name;
            item.Done = done;

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var item = db.TodoItems.Single(x => x.Id == id);

            return View(item);
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            var item = db.TodoItems.Single(x => x.Id == id);
            db.TodoItems.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var item = db.TodoItems.Single(x => x.Id == id);
            return View(item);
        }
    }
}