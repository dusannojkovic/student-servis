using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Student_servis.Dto;
using Student_servis.Models;

namespace Student_servis.Repository
{
    public class StudentIspitRepository : IStudentIspitRepository
    {
        private ServisEntities dbContext;

        public StudentIspitRepository()
        {
            dbContext = new ServisEntities();

        }

        public StudentIspitRepository(ServisEntities dbContext)
        {
            dbContext = this.dbContext;
        }

        public void Add(StudentIspitDto obj)
        {
           
            dbContext.StudentIspits.Add(new StudentIspit {
                id_Student = obj.idStudent,
                id_Ispit = obj.idIspit,
                Ocena = obj.Ocena
            });
        }

        public IEnumerable<StudentIspit> GetAll()
        {
            return dbContext.StudentIspits;
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }
    }
}