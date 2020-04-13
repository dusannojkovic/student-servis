using Student_servis.Dto;
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
    public class StudentIspitController : Controller
    {
        IStudentRepository _student = new StudentRepository();
        IIspitRepository ispit = new IspitRepository();
        IStudentIspitRepository studentIspit = new StudentIspitRepository();


        // GET: StudentIspit
        public ActionResult Create()
        {
            ViewBag.students = _student.GetAll().Where(s => s.Aktivan == 1);
            ViewBag.ispits = ispit.GetAll().Where(i => i.Aktivan == 1);
            return View("Create");
        }
        [HttpPost]
        public ActionResult Create(StudentIspitDto obj)
        {
            ViewBag.students = _student.GetAll().Where(s => s.Aktivan == 1);
            ViewBag.ispits = ispit.GetAll().Where(i => i.Aktivan == 1);
            try
            {
                
                if (ModelState.IsValid)
                {
                    studentIspit.Add(obj);
                    studentIspit.Save();
                    return RedirectToAction("Dnevnik", "StudentIspit");
                }
                return View("Create",obj);
                
            }
            catch (Exception e)
            {
                ViewBag.Error = e.InnerException.Message;
                return View();
            }
        }

       
        public ActionResult Dnevnik()
        {
            var podaci = (from s in _student.GetAll().ToList()
                             join si in studentIspit.GetAll().ToList()
                             on s.idStudent equals si.id_Student
                             join i in ispit.GetAll().ToList()
                             on si.id_Ispit equals i.idIspit
                             select new StudentIspitDto
                             {
                                 Student = s,
                                 Ispit = i,
                                 Ocena = si.Ocena
                             }).ToList();
            ViewBag.podaci = podaci;
            return View();
        }
        public ActionResult Pojedinacna()
        {
            var podaci = _student.GetAll().ToList();
            ViewBag.podaci = podaci;
            
            return View();
        }
        
        public ActionResult JedanStudent(int idStudent)
        {
            var podaci = (from s in _student.GetAll().ToList()
                          join si in studentIspit.GetAll().ToList()
                          on s.idStudent equals si.id_Student
                          join i in ispit.GetAll().ToList()
                          on si.id_Ispit equals i.idIspit
                          where s.idStudent.Equals(idStudent)
                          select new StudentIspitDto
                          {
                              Student = s,
                              idStudent = s.idStudent,
                              idIspit = i.idIspit,
                              Ispit = i,
                              Ocena = si.Ocena
                          }).ToList();
            ViewBag.podaci = podaci;
            return PartialView("Jedan");
        }

        
    }
}
