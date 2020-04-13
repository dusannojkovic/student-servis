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
    
    public class StudentController : Controller
    {
        
        IStudentRepository _student = new StudentRepository();

      

        public ActionResult Index()
        {
            
            var all = _student.GetAll();
            return View(all.ToList());
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var jedanStudent = _student.GetbyId(id);
                return View("Details", jedanStudent);
            }
            catch (EntityNotFoundException)
            {
                TempData["error"] = "Ne postoji student!";
            }
            return View();

        }

        // GET: Student/Create
        public ActionResult Create()
        {

            return View("Create");
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(StudentDto obj)
        {
            
               
                if (_student.IsExist(obj))
                {
                    ModelState.AddModelError("Broj_indeks", "Student sa tim brojem indeksa vec postoji");
                    
                    
                }
                if (ModelState.IsValid)
                {
                    _student.Add(obj);
                    _student.Save();
                    return RedirectToAction("Index", "Student");
                }
                return View(obj);
                
         }
          
        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            var jedanStudent = _student.GetbyId(id);
            ViewBag.Ime = jedanStudent.Ime;
            ViewBag.Prezime = jedanStudent.Prezime;
            ViewBag.Adresa = jedanStudent.Adresa;
            ViewBag.Datum = jedanStudent.Datum_rodjenja;
            ViewBag.Indeks = jedanStudent.Broj_indeks;
            return View();
            
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, StudentDto obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _student.Update(id, obj);
                    _student.Save();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            var jedanStudent = _student.GetbyId(id);
            return View(jedanStudent);
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, StudentDto obj)
        {
            try
            {
                _student.Delete(id);
                _student.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
