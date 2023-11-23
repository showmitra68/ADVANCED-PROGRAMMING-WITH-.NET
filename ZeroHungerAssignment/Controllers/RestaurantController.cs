﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHungerAssignment.DB;

namespace ZeroHungerAssignment.Controllers
{
    public class RestaurantController : Controller
    {
        // GET: Restaurant

        public ActionResult Add()
        {
            return View();
        }

        // POST: Restaurant/Add
        [HttpPost]
        public ActionResult Add(Restaurant restaurant)
        {
            using (var db = new ZeroHungerEntities())
            {
                db.Restaurants.Add(restaurant);
                db.SaveChanges();
                TempData["msg"] = "Restaurant Add Successfull";
                return RedirectToAction("Add", "Restaurant");
            }
        }
        public ActionResult Index()
        {
            using (var db = new ZeroHungerEntities())
            {
                var requests = db.Restaurants.ToList();
                return View(requests);
            }
        }

        public ActionResult Create()
        {
            using (var db = new ZeroHungerEntities())
            {
                var restaurants = db.Restaurants
                                .Include(r => r.CollectRequests)
                                .ToList();
                var name = db.Restaurants.ToList();

                ViewBag.Name = name;

                return View(restaurants);

            }
        }

        [HttpPost]
        public ActionResult Create(CollectRequest request, int RestaurantID)
        {
            if (ModelState.IsValid)
            {
                using (var db = new ZeroHungerEntities())
                {
                    request.RestaurantID = RestaurantID;
                    int EmployeeId = 0;
                    request.EmployeeId = EmployeeId;
                    request.Status = "Pending";
                    db.CollectRequests.Add(request);
                    db.SaveChanges();
                    TempData["msg"] = "Request Successfull";
                    return RedirectToAction("Create");
                }
            }

            return View(request);
        }

        public ActionResult Accpect(int id)
        {
            using (var db = new ZeroHungerEntities())
            {
                var request = db.CollectRequests.Find(id);

                if (request != null)
                {
                    request.Status = "Accpect";
                    db.Entry(request).State = EntityState.Modified;
                    db.SaveChanges();

                    TempData["msg"] = "Request marked as Accpected successfully!";
                }
                else
                {
                    TempData["error"] = "Invalid request!";
                }
            }

            return RedirectToAction("Create");
        }

        public ActionResult Reject(int id)
        {
            using (var db = new ZeroHungerEntities())
            {
                var request = db.CollectRequests.Find(id);

                if (request != null)
                {
                    request.Status = "Reject";
                    db.Entry(request).State = EntityState.Modified;
                    db.SaveChanges();

                    TempData["msg"] = "Request marked as Rejected successfully!";
                }
                else
                {
                    TempData["error"] = "Invalid request!";
                }
            }

            return RedirectToAction("Create");
        }

        public ActionResult AccpectData()
        {
            using (var db = new ZeroHungerEntities())
            {
                var restaurant = db.Restaurants
                                .Include(r => r.CollectRequests)
                                .ToList();

                var employees = db.Employees.ToList();
                ViewBag.Employees = employees;

                return View(restaurant);
            }
        }

        public ActionResult RejectData()
        {
            using (var db = new ZeroHungerEntities())
            {
                var restaurant = db.Restaurants
                                .Include(r => r.CollectRequests)
                                .ToList();

                return View(restaurant);
            }
        }

        public ActionResult completData()
        {
            using (var db = new ZeroHungerEntities())
            {
                var restaurant = db.Restaurants
                                .Include(r => r.CollectRequests)
                                .ToList();

                return View(restaurant);
            }
        }

        public ActionResult Edit(int ID)
        {
            using (var db = new ZeroHungerEntities())
            {
                var restaurant = db.Restaurants.Find(ID);
                if (restaurant == null)
                {
                    return HttpNotFound();
                }

                ViewBag.Id = restaurant.ID;
                ViewBag.Name = restaurant.Name;
                ViewBag.ContactInfo = restaurant.ContactInfo;
                ViewBag.Address = restaurant.Address;

                return View();
            }
        }


        [HttpPost]
        public ActionResult Edit(Restaurant restaurant)
        {
            using (var db = new ZeroHungerEntities())
            {
                var upd = (from p in db.Restaurants
                           where p.ID == restaurant.ID
                           select p).SingleOrDefault();
                db.Entry(upd).CurrentValues.SetValues(restaurant);
                db.SaveChanges();
                TempData["msg"] = "Edit Successfull";

                return RedirectToAction("Edit");
            }
        }


        public ActionResult Delete(int id)
        {
            using (var db = new ZeroHungerEntities())
            {
                var request = db.Restaurants.Find(id);
                if (request == null)
                {
                    return HttpNotFound();
                }
                else
                    db.Restaurants.Remove(request);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

    }
}