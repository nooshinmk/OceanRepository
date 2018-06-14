using Microsoft.AspNet.Identity;
using OceanSystem.Models;
using OceanSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OceanSystem.Controllers
{
    public class GigsController : Controller
    {
        private readonly OceanDbContext _context;

        public GigsController()
        {
            _context = new OceanDbContext();

        }

        // GET: Gigs
        public ActionResult Index()
        {
            return View();
        }

        // GET: Gigs/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: Gigs/Create
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new GigViewModel
            {
                Genres = _context.Genre.ToList()
            };

            return View(viewModel);
        }

        // POST: Gigs/Create
        [HttpPost]
        [Authorize]
        public ActionResult Create(GigViewModel formModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    formModel.Genres = _context.Genre.ToList();
                    return View("Create", formModel);
                }
                var gig = new Gig
                {
                    ArtistId = User.Identity.GetUserId(),
                    GenreId = formModel.Genre,
                    Venue = formModel.Venue,
                    DateTime = formModel.GetDateTime()
                };

                _context.Gig.Add(gig);
                _context.SaveChanges();
                return RedirectToAction("Index");



            }
            catch (Exception ex)
            {
                var errorMessage = ex.Message;//OR ex.ToString(); OR Free text OR an custom object

                return View();
            }
        }

        //// GET: Gigs/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Gigs/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Gigs/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Gigs/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
