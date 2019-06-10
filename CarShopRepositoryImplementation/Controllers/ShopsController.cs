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
    public class ShopsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShopsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ShopsController()
        {

        }

        // GET: Shops
        public ActionResult Index()
        {
            var shops = _unitOfWork.Shops.GetAll();
            return View(shops);
        }

        // GET: Shops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shop shop = _unitOfWork.Shops.SingleOrDefault(c => c.Id == id);
            if (shop == null)
            {
                return HttpNotFound();
            }
            return View(shop);
        }

        // GET: Shops/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shops/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Address")] Shop shop)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Shops.Add(shop);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }

            return View(shop);
        }

        // GET: Shops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shop shop = _unitOfWork.Shops.SingleOrDefault(c => c.Id == id);
            if (shop == null)
            {
                return HttpNotFound();
            }
            return View(shop);
        }

        // POST: Shops/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Address")] Shop shop)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Shops.Update(shop);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            return View(shop);
        }

        // GET: Shops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Shop shop = _unitOfWork.Shops.SingleOrDefault(s => s.Id == id);
            if (shop == null)
            {
                return HttpNotFound();
            }
            return View(shop);
        }

        // POST: Shops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Shop shop = _unitOfWork.Shops.SingleOrDefault(s => s.Id == id);
            _unitOfWork.Shops.Remove(shop);
            _unitOfWork.Complete();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        _unitOfWork.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
