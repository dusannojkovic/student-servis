using Student_servis.Dto;
using Student_servis.Exceptions;
using Student_servis.Models;
using Student_servis.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Student_servis.Controllers
{
    [HandleError]
    public class IspitController : Controller
    {
        IIspitRepository ispit = new IspitRepository();

        // GET: Ispit
        public ActionResult Index()
        {
            var ispiti = ispit.GetAll();
            return View(ispiti.ToList());
        }

        // GET: Ispit/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var ispitJedan = ispit.GetbyId(id);
                return View(ispitJedan);
            }
            catch (EntityNotFoundException)
            {
                TempData["error"] = "Ne postoji ispit!";
            }
            return View();

        }

        // GET: Ispit/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Ispit/Create
        [HttpPost]
        public ActionResult Create(IspitDto obj)
        {
            
                if (ispit.GetAll().Any(i => i.Naziv == obj.Naziv))
                {
                    ModelState.AddModelError("Naziv", "Ispit sa tim nazivom vec postoji");
                }
                if (ModelState.IsValid)
                {
                    ispit.Add(obj);
                    ispit.Save();
                    return RedirectToAction("Index");
                }
                return View(obj);
                
         }
 

        // GET: Ispit/Edit/5
        public ActionResult Edit(int id)
        {
            var ispitJedan = ispit.GetbyId(id);
            ViewBag.Naziv  = ispitJedan.Naziv;
            ViewBag.Datum =  ispitJedan.Datum.ToString("dd/MM/yyyy");
            return View();
        }

        // POST: Ispit/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, IspitDto obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ispit.Update(id,obj);
                    ispit.Save();
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                TempData["error"] = e.Message;
                return View();
            }
        }

        // GET: Ispit/Delete/5
        public ActionResult Delete(int id)
        {
            var jedanIspit = ispit.GetbyId(id);
            return View(jedanIspit);

        }

        // POST: Ispit/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, IspitDto obj)
        {
            try
            {
                
                    ispit.Delete(id);
                    ispit.Save();
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
