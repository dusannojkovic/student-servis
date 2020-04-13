using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Student_servis.Models;
using Student_servis.Dto;
using Student_servis.Exceptions;

namespace Student_servis.Repository
{
    public class StudentRepository : IStudentRepository
    {

        private ServisEntities dbContext;

        public StudentRepository()
        {
            dbContext = new ServisEntities();
        }

        public StudentRepository(ServisEntities dbContext)
        {
            dbContext = this.dbContext;
        }

        public void Add(StudentDto obj)
        {
           
            dbContext.Students.Add(new Student
            {
                Ime = obj.Ime,
                Prezime = obj.Prezime,
                Adresa = obj.Adresa,
                Datum_rodjenja = obj.Datum_rodjenja,
                Broj_index = obj.Broj_indeks,
                Aktivan = 1
            });
        }

        public void Delete(int studentId)
        {
            var studentJedan = dbContext.Students.Find(studentId);
            if (studentJedan == null)
            {
                throw new EntityNotFoundException("Student ");
            }
            studentJedan.Aktivan = 0;
        }

        public IEnumerable<Student> GetAll()
        {
            return dbContext.Students.Where(x => x.Aktivan == 1);
        }

        public StudentDto GetbyId(int studentId)
        {
            var find = dbContext.Students.Find(studentId);
            if (find == null)
            {
                throw new EntityNotFoundException("Student ");
            }
            return new StudentDto
            {
                idStudent =find.idStudent,
                Ime = find.Ime,
                Prezime = find.Prezime,
                Adresa = find.Adresa,
                Datum_rodjenja = find.Datum_rodjenja,
                Broj_indeks = find.Broj_index,
                Aktivan = find.Aktivan
            };
        }

        public bool IsExist(StudentDto obj)
        {
            if(dbContext.Students.Any(s => s.Broj_index == obj.Broj_indeks))
            {
                return true;
            }
            return false;
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        public void Update(int id,StudentDto obj)
        {
            var find = dbContext.Students.Find(id);
            if (find == null)
            {
                throw new EntityNotFoundException("Student ");
            }
            find.Ime = obj.Ime;
            find.Prezime = obj.Prezime;
            find.Adresa = obj.Adresa;
            find.Datum_rodjenja = obj.Datum_rodjenja;
            find.Broj_index = obj.Broj_indeks;

        }
    }
}