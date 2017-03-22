using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VM.DisasterRecovery.Common.Models;
using VM.DisasterRecovery.Domain.Models;
using VM.DisasterRecovery.Persistence;
using VM.DisasterRecovery.Persistence.Context;
using VM.DisasterRecovery.Persistence.Contracts;
using VM.DisasterRecovery.Services.Managers;
using VM.DisasterRecovery.Web.Areas.Management.Models;

namespace VM.DisasterRecovery.Web.Areas.Management.Controllers
{
    public class JobController : Controller
    {
        private readonly JobManager _manager;

        public JobController() 
            : this (UnitOfWork.Initialize()) { }

        public JobController(IUnitOfWork unitOfWork) 
            : this(JobManager.Initialize(unitOfWork)) { }

        public JobController(JobManager manager)
        {
            _manager = manager;
        }

        // GET: Management/Job
        [HttpGet]
        public ActionResult Index()
        {
            return View(_manager.GellAll());
        }

        // GET: Management/Job/Details/5
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var model = _manager.Get(id.Value);

            if (model == null)
                return HttpNotFound();

            return View(model);
        }

        // GET: Management/Job/Create
        [HttpGet]
        public ActionResult Create()
        {
            var model = JobViewModel.Initialize();
            return View(model);
        }

        // POST: Management/Job/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JobViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var job = model.ConvertToJob();
            OperationResult result = _manager.Create(job);

            if (!result.Success)
            {
                //TODO: Add Messaging
                return View(model); ;
            }

            return RedirectToAction("Details", new { id = job.Id });
        }

        // GET: Management/Job/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var job = _manager.Get(id.Value);

            if (job == null)
                return HttpNotFound();

            var model = JobViewModel.Initialize(job);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(JobViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var job = model.ConvertToJob();

            _manager.Edit(job);

            OperationResult result = _manager.Edit(job);

            if (!result.Success)
            {
                //TODO: Add Messaging
                return View(model);
            }

            return RedirectToAction("Details", new { id = job.Id });
        }

        // GET: Management/Job/Delete/5
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var job = _manager.Get(id.Value);

            if (job == null)
                return HttpNotFound();

            return View(job);
        }

        // POST: Management/Job/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var job = _manager.Get(id);

            _manager.Delete(job);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _manager.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
