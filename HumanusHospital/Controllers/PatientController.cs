using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HumanusHospital.DAL;
using HumanusHospital.Models;
using PagedList;

namespace HumanusHospital.Controllers
{
    public class PatientController : Controller
    {
        private HospitalContext db = new HospitalContext();

        // GET: Patient
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.FnameSortParm = sortOrder == "Fname" ? "fname_desc" : "Fname";
            ViewBag.CitySortParm = sortOrder == "City" ? "city_desc" : "City";
            ViewBag.IDSortParm = sortOrder == "ID" ? "id_desc" : "ID";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var patients = from p in db.Patients
                           select p;
            if (!String.IsNullOrEmpty(searchString))
            {
                patients = patients.Where(p => p.LastName.Contains(searchString)
                                       || p.PersonIDNr.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    patients = patients.OrderByDescending(p => p.LastName);
                    break;
                case "Fname":
                    patients = patients.OrderBy(p => p.FirstName);
                    break;
                case "fname_desc":
                    patients = patients.OrderByDescending(p => p.FirstName);
                    break;
                case "City":
                    patients = patients.OrderBy(p => p.City);
                    break;
                case "city_desc":
                    patients = patients.OrderByDescending(p => p.City);
                    break;
                case "ID":
                    patients = patients.OrderBy(p => p.PersonIDNr);
                    break;
                case "id_desc":
                    patients = patients.OrderByDescending(p => p.PersonIDNr);
                    break;
                default:
                    patients = patients.OrderBy(p => p.LastName);
                    break;
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(patients.ToPagedList(pageNumber, pageSize));
        }

        // GET: Patient/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // GET: Patient/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Patient/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonIDNr,FirstName,LastName,Address,Zipcode,City,Phone,Email,Room")] Patient patient)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Patients.Add(patient);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(patient);
        }

        // GET: Patient/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patient/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var patientToUpdate = db.Patients.Find(id);
            if (TryUpdateModel(patientToUpdate, "",
               new string[] { "PersonIDNr", "FirstName", "LastName", "Address", "Zipcode", "City", "Phone", "Email", "Room" }))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (DataException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(patientToUpdate);
        }

        // GET: Patient/Delete/5
        public ActionResult Delete(string id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patient/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id)
        {
            try
            {
                Patient patient = db.Patients.Find(id);
                db.Patients.Remove(patient);
                db.SaveChanges();
            }
            catch (DataException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id, saveChangesError = true });
            }
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
