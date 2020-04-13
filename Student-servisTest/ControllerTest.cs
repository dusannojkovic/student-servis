using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Student_servis.Controllers;
using System.Web.Mvc;
using Student_servis.Repository;
using System.Collections.Generic;
using Student_servis.Models;
using Student_servis.Dto;

namespace Student_servisTest
{
    [TestClass]
    public class ControllerTest
    {
        IStudentRepository _student = new StudentRepository();
        StudentController controller = new StudentController();

        [TestMethod]
        public void Details()
        {
            
            var result = controller.Details(1) as ViewResult;
            Assert.AreEqual("Details", result.ViewName);
        }
        [TestMethod]
        public void Index()
        {
         
            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }
        [TestMethod]
       public void Edit()
        {
            var result = controller.Edit(1) as ViewResult;
            var studentIme = _student.GetbyId(1);

            Assert.AreEqual(studentIme.Ime,"Dusan");
        }
        [TestMethod]
        public void Delete()
        {
            ViewResult result = controller.Delete(1) as ViewResult;
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void Create()
        {
            ViewResult result = controller.Create() as ViewResult;
            Assert.AreEqual("Create",result.ViewName);
        }
    }
}
