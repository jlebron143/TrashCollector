using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class DriverRoutesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DriverRoutes
        public ActionResult Index()
        {
            return View(db.DriverRoutes.ToList());
        }

        // GET: DriverRoutes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DriverRoute driverRoute = db.DriverRoutes.Find(id);
            if (driverRoute == null)
            {
                return HttpNotFound();
            }
            return View(driverRoute);
        }

        // GET: DriverRoutes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DriverRoutes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CustomerId,WorkersId")] DriverRoute driverRoute)
        {
            if (ModelState.IsValid)
            {
                db.DriverRoutes.Add(driverRoute);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(driverRoute);
        }

        // GET: DriverRoutes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DriverRoute driverRoute = db.DriverRoutes.Find(id);
            if (driverRoute == null)
            {
                return HttpNotFound();
            }
            return View(driverRoute);
        }

        // POST: DriverRoutes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CustomerId,WorkersId")] DriverRoute driverRoute)
        {
            if (ModelState.IsValid)
            {
                db.Entry(driverRoute).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(driverRoute);
        }

        // GET: DriverRoutes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DriverRoute driverRoute = db.DriverRoutes.Find(id);
            if (driverRoute == null)
            {
                return HttpNotFound();
            }
            return View(driverRoute);
        }

        // POST: DriverRoutes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DriverRoute driverRoute = db.DriverRoutes.Find(id);
            db.DriverRoutes.Remove(driverRoute);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
