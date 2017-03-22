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
    public class SupplyController : Controller
    {
        private readonly SupplyManager _manager;

        public SupplyController() 
            : this (UnitOfWork.Initialize()) { }

        public SupplyController(IUnitOfWork unitOfWork) 
            : this(SupplyManager.Initialize(unitOfWork)) { }

        public SupplyController(SupplyManager manager)
        {
            _manager = manager;
        }

        // GET: Management/Disaster
        [HttpGet]
        public ActionResult Index()
        {
            return View(_manager.GellAll());
        }

        // GET: Management/Disaster/Details/5
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

        // GET: Management/Disaster/Create
        [HttpGet]
        public ActionResult Create()
        {
            var model = SupplyViewModel.Initialize();
            return View(model);
        }

        // POST: Management/Disaster/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SupplyViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var supply = model.ConvertToSupply();
            OperationResult result = _manager.Create(supply);

            if (!result.Success)
            {
                //TODO: Add Messaging
                return View(model); ;
            }

            return RedirectToAction("Details", new { id = supply.Id });
        }

        // GET: Management/Disaster/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var supply = _manager.Get(id.Value);

            if (supply == null)
                return HttpNotFound();

            var model = SupplyViewModel.Initialize(supply);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SupplyViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var supply = model.ConvertToSupply();

            _manager.Edit(supply);

            OperationResult result = _manager.Edit(supply);

            if (!result.Success)
            {
                //TODO: Add Messaging
                return View(model);
            }

            return RedirectToAction("Details", new { id = supply.Id });
        }

        // GET: Management/Disaster/Delete/5
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var supply = _manager.Get(id.Value);

            if (supply == null)
                return HttpNotFound();

            return View(supply);
        }

        // POST: Management/Disaster/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var supply = _manager.Get(id);

            _manager.Delete(supply);

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
