using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCPractic.Models;

namespace MVCPractic.Controllers
{
    public class tbContentController : Controller
    {
        private tbContentDbContext db = new tbContentDbContext();

        // GET: tbContent
        public ActionResult Index()
        {
            return View(db.Contents.ToList());
        }

        // GET: tbContent/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbContent tbContent = db.Contents.Find(id);
            if (tbContent == null)
            {
                return HttpNotFound();
            }
            return View(tbContent);
        }

        // GET: tbContent/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbContent/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContentId,ContentPic")] tbContent tbContent)
        {
            if (ModelState.IsValid)
            {
                db.Contents.Add(tbContent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbContent);
        }

        // GET: tbContent/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbContent tbContent = db.Contents.Find(id);
            if (tbContent == null)
            {
                return HttpNotFound();
            }
            return View(tbContent);
        }

        // POST: tbContent/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContentId,ContentPic")] tbContent tbContent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbContent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbContent);
        }

        // GET: tbContent/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbContent tbContent = db.Contents.Find(id);
            if (tbContent == null)
            {
                return HttpNotFound();
            }
            return View(tbContent);
        }

        // POST: tbContent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbContent tbContent = db.Contents.Find(id);
            db.Contents.Remove(tbContent);
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
