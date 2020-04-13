using Student_servis.Dto;
using Student_servis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_servis.Repository
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();
        StudentDto GetbyId(int studentId);
        void Add(StudentDto obj);
        void Update(int id,StudentDto obj);
        void Delete(int studentId);
        void Save();
        bool IsExist(StudentDto obj);

    }
}
