
using System.Net;
using System.Web.Mvc;
using VM.DisasterRecovery.Common.Models;
using VM.DisasterRecovery.Domain.Models;
using VM.DisasterRecovery.Persistence;
using VM.DisasterRecovery.Persistence.Contracts;
using VM.DisasterRecovery.Services;
using VM.DisasterRecovery.Web.Areas.Management.Models;

namespace VM.DisasterRecovery.Web.Areas.Management.Controllers
{
    public class DisasterController : Controller
    {
        private readonly DisasterManager _manager;

        public DisasterController() 
            : this (UnitOfWork.Initialize()) { }

        public DisasterController(IUnitOfWork unitOfWork) 
            : this(DisasterManager.Initialize(unitOfWork)) { }

        public DisasterController(DisasterManager manager)
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

            if (model == null || model.Deleted)
                return HttpNotFound();

            return View(model);
        }

        // GET: Management/Disaster/Create
        [HttpGet]
        public ActionResult Create()
        {
            DisasterViewModel model = new DisasterViewModel();
            return View(model);
        }

        // POST: Management/Disaster/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DisasterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            Disaster disaster = model.ConvertToDisaster();
            OperationResult result = _manager.Create(disaster);

            if (!result.Success)
            {
                //TODO: Add Messaging
                return View(model); ;
            }

            return RedirectToAction("Details", new {id = disaster.Id});
        }

        // GET: Management/Disaster/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Disaster disaster = _manager.Get(id.Value);

            if (disaster == null || disaster.Deleted)
                return HttpNotFound();
            
            var model = DisasterViewModel.Initialize(disaster);
            
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DisasterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            Disaster disaster = model.ConvertToDisaster();

            _manager.Edit(disaster);

            OperationResult result = _manager.Create(disaster);

            if (!result.Success)
            {
                //TODO: Add Messaging
                return View(model);
            }

            return RedirectToAction("Details", new { id = disaster.Id });
        }

        // GET: Management/Disaster/Delete/5
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Disaster disaster = _manager.Get(id.Value);

            if (disaster == null || disaster.Deleted)
                return HttpNotFound();

            return View(disaster);
        }

        // POST: Management/Disaster/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var disaster = _manager.Get(id);

            _manager.Delete(disaster);

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
