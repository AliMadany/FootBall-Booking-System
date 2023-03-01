using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using M3gogo.BLL;
using M3gogo.Models;
using M3gogo.DBLayer;


namespace M3gogo.Controllers
{
    public class ClubsNeverMatchedController : Controller
    {


        ClubBLL nevermatchedBLL = new ClubBLL();


        // GET: ClubsNeverMatched
        public ActionResult Index()
        {
            return View();
        }

        // GET: ClubsNeverMatched/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClubsNeverMatched/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClubsNeverMatched/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ClubsNeverMatched/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClubsNeverMatched/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ClubsNeverMatched/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClubsNeverMatched/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        [HttpGet]

        public ActionResult getClubsNeverMatched() // display view UI form to enter club details get method
        {

            return View();
        }
        [HttpPost]
        public ActionResult getClubsNeverMatched(clubsNeverMatched test) // post method to get called automatically after user clicks submit button to submit form to db with club model data
        {


            nevermatchedBLL.getclubsnevermatch(test);



            return View(test);
        }



        [HttpGet]

        public ActionResult getClubsNevermatchView() // post method to get called automatically after user clicks submit button to submit form to db with club model data
        {


            List<clubsNeverMatched> list = nevermatchedBLL.testView().ToList();

            return View(list);
        }
    }
}
