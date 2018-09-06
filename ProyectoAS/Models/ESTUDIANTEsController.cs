using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProyectoAS.Models
{
    public class ESTUDIANTEsController : Controller
    {
        private ArquitecturaSoftwareEntities db = new ArquitecturaSoftwareEntities();

        // GET: ESTUDIANTEs
        public ActionResult Index()
        {
            var eSTUDIANTEs = db.ESTUDIANTEs.Include(e => e.GENERO).Include(e => e.TIPO_DOC);
            return View(eSTUDIANTEs.ToList());
        }

        // GET: ESTUDIANTEs/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTUDIANTE eSTUDIANTE = db.ESTUDIANTEs.Find(id);
            if (eSTUDIANTE == null)
            {
                return HttpNotFound();
            }
            return View(eSTUDIANTE);
        }

        // GET: ESTUDIANTEs/Create
        public ActionResult Create()
        {
            ViewBag.ID_GENERO = new SelectList(db.GENEROes, "ID_GENERO", "ABREVIATURA");
            ViewBag.ID_TIPO_DOC = new SelectList(db.TIPO_DOC, "ID_TIPO_DOC", "ABREVIATURA");
            return View();
        }

        // POST: ESTUDIANTEs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_ESTUDIANTE,ID_TIPO_DOC,NUMERO_IDENTIFICACION,PRIMER_NOMBRE,SEGUNDO_NOMBRE,PRIMER_APELLIDO,SEGUNDO_APELLIDO,ID_GENERO,CELULAR")] ESTUDIANTE eSTUDIANTE)
        {
            if (ModelState.IsValid)
            {
                db.ESTUDIANTEs.Add(eSTUDIANTE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_GENERO = new SelectList(db.GENEROes, "ID_GENERO", "ABREVIATURA", eSTUDIANTE.ID_GENERO);
            ViewBag.ID_TIPO_DOC = new SelectList(db.TIPO_DOC, "ID_TIPO_DOC", "ABREVIATURA", eSTUDIANTE.ID_TIPO_DOC);
            return View(eSTUDIANTE);
        }

        // GET: ESTUDIANTEs/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTUDIANTE eSTUDIANTE = db.ESTUDIANTEs.Find(id);
            if (eSTUDIANTE == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_GENERO = new SelectList(db.GENEROes, "ID_GENERO", "ABREVIATURA", eSTUDIANTE.ID_GENERO);
            ViewBag.ID_TIPO_DOC = new SelectList(db.TIPO_DOC, "ID_TIPO_DOC", "ABREVIATURA", eSTUDIANTE.ID_TIPO_DOC);
            return View(eSTUDIANTE);
        }

        // POST: ESTUDIANTEs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_ESTUDIANTE,ID_TIPO_DOC,NUMERO_IDENTIFICACION,PRIMER_NOMBRE,SEGUNDO_NOMBRE,PRIMER_APELLIDO,SEGUNDO_APELLIDO,ID_GENERO,CELULAR")] ESTUDIANTE eSTUDIANTE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eSTUDIANTE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_GENERO = new SelectList(db.GENEROes, "ID_GENERO", "ABREVIATURA", eSTUDIANTE.ID_GENERO);
            ViewBag.ID_TIPO_DOC = new SelectList(db.TIPO_DOC, "ID_TIPO_DOC", "ABREVIATURA", eSTUDIANTE.ID_TIPO_DOC);
            return View(eSTUDIANTE);
        }

        // GET: ESTUDIANTEs/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTUDIANTE eSTUDIANTE = db.ESTUDIANTEs.Find(id);
            if (eSTUDIANTE == null)
            {
                return HttpNotFound();
            }
            return View(eSTUDIANTE);
        }

        // POST: ESTUDIANTEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ESTUDIANTE eSTUDIANTE = db.ESTUDIANTEs.Find(id);
            db.ESTUDIANTEs.Remove(eSTUDIANTE);
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
