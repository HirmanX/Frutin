﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace Frutin.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        private UnitGenericRepository db = new UnitGenericRepository();

        // GET: Admin/Users
        public ActionResult Index()
        {
            var user = db.UserRepository.Get(includes:"Shop");
            return View(user);
        }

        // GET: Admin/Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.UserRepository.GetById(id.Value);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Admin/Users/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.ShopRepository.Get(), "ShopID", "Name");
            return View();
        }

        // POST: Admin/Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,FirstName,LastName,Email,ImageName,IsSeller")] User user)
        {
            if (ModelState.IsValid)
            {
                db.UserRepository.Insert(user);
                db.SaveChange();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.ShopRepository.Get(), "ShopID", "Name", user.UserID);
            return View(user);
        }

        // GET: Admin/Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.UserRepository.GetById(id.Value);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.ShopRepository.Get(), "ShopID", "Name", user.UserID);
            return View(user);
        }

        // POST: Admin/Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,FirstName,LastName,Email,ImageName,IsSeller")] User user)
        {
            if (ModelState.IsValid)
            {
                db.UserRepository.Update(user);
                db.SaveChange();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.ShopRepository.Get(), "ShopID", "Name", user.UserID);
            return View(user);
        }

        // GET: Admin/Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.UserRepository.GetById(id.Value);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Admin/Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.UserRepository.Delete(id);
            db.SaveChange();
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
