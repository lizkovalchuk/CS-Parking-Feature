using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using parkingApp.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace parkingApp.Controllers
{
    public class parkingController : Controller
    {
        HospitalContext db = new HospitalContext();


//=======================================================
//                BUY PARKING PASS
//=======================================================


        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        //Get: get the info from the user
        [HttpGet]
        public ActionResult Add()
        {
            try
            {
                return View();
            }
            catch (Exception genericException)
            {
                ViewBag.ExceptionMessage = genericException;
            }
            return View();
        }

        //Post: 
        [HttpPost]
        public ActionResult Add(Parking parking)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Parkings.Add(parking);
                    db.SaveChanges();
                }
            }
            catch (Exception genericException)
            {
                ViewBag.ExceptionMessage = genericException;
            }
            return RedirectToAction("Index");
        }

//=======================================================
//                LOGIN FOR ADMIN
//=======================================================

        //Shows the AdminLogin Page
        public ActionResult AdminLogin()
        {
            return View();
        }

        //Check that admin exists
        [HttpPost]
        public ActionResult AdminLogin(ParkingAdmin parkingAdmin)
        {
            List<ParkingAdmin> pa = db.ParkingAdmins.Where(PA => PA.Email == parkingAdmin.Email
                                                           &&
                                                           PA.Password == parkingAdmin.Password).ToList();
            return RedirectToAction("AdminIndex", "parking");
        }

//=======================================================
//                ADMIN - CREATE PARKING TABLE
//=======================================================

        //[Authorize(Roles = "Admin")]


        [HttpGet]
        public ActionResult AdminCreate()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AdminCreate(Parking parking)
        {
            if (ModelState.IsValid)
            {
                db.Parkings.Add(parking);
                db.SaveChanges();
            }
            return RedirectToAction("AdminIndex");
        }





//=======================================================
//                ADMIN - READ PARKING TABLE
//=======================================================

        //[Authorize(Roles = "Admin")]
        public ActionResult AdminIndex()
        {            
            return View(db.Parkings.ToList());
        }


//=======================================================
//                ADMIN - DETAILS PARKING TABLE
//=======================================================

        [HttpGet]
        public ActionResult AdminDetails(int Id)
        {
            Parking parking = db.Parkings.SingleOrDefault(model=>model.Id == Id);
            return View(parking);
        }

//=======================================================
//                ADMIN - DELETE PARKING TABLE
//=======================================================

        public ActionResult AdminDelete(int Id)
        {
            Parking parking = db.Parkings.SingleOrDefault(model => model.Id == Id);
            if(parking == null)
            {
                return RedirectToAction("AdminIndex");
            }
            db.Parkings.Remove(parking);
            db.SaveChanges();

            return RedirectToAction("AdminIndex");
        }

//=======================================================
//                ADMIN - UPDATE PARKING TABLE
//=======================================================

        [HttpGet]
        public ActionResult AdminUpdate(int Id)
        {
            Parking parking = db.Parkings.SingleOrDefault(model => model.Id == Id);
            return View(parking);
        }

        [HttpPost]
        public ActionResult AdminUpdate(Parking parking)
        {
            db.Entry(parking).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("AdminIndex", "parking");
        }

        //=======================================================
        //                LOGOUT FOR ADMIN
        //=======================================================

        public ActionResult Logout()
        {
            //FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }



    } //end of class
} //end of namespace