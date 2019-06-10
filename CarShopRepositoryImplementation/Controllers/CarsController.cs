using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarShopRepositoryImplementation.Core;
using CarShopRepositoryImplementation.Core.Domain;
using CarShopRepositoryImplementation.Persistence;

namespace CarShopRepositoryImplementation.Controllers
{
    public class CarsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CarsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CarsController()
        {

        }
        // GET: Cars
        public ActionResult Index()
        {
            var cars = _unitOfWork.Cars.GetAll();
            return View(cars);
        }

        // GET: Cars/Details/5
        public ActionResult Details(int? id)
        {
            Car car = _unitOfWork.Cars.SingleOrDefault(c => c.Id == id);
            return View(car);
        }

        // GET: Cars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CarModel,CarMake")] Car car)
        {
            _unitOfWork.Cars.Add(car);
            _unitOfWork.Complete();
            return View(car);
        }

        // GET: Cars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Car car = _unitOfWork.Cars.SingleOrDefault(c => c.Id == id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CarModel,CarMake")] Car car)
        {
            if (ModelState.IsValid)
            {
                if (TryUpdateModel(car))
                {
                    _unitOfWork.Cars.Update(car);
                    _unitOfWork.Complete();
                }

                return RedirectToAction("Index");
            }
            return View(car);
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Car car = _unitOfWork.Cars.SingleOrDefault(s => s.Id == id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Car car = _unitOfWork.Cars.SingleOrDefault(s => s.Id == id);
            _unitOfWork.Cars.Remove(car);
            _unitOfWork.Complete();
            return RedirectToAction("Index");
        }

    }
}
