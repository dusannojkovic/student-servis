using Student_servis.Dto;
using Student_servis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_servis.Repository
{
    public interface IStudentIspitRepository
    {
        IEnumerable<StudentIspit> GetAll();
        void Add(StudentIspitDto obj);
        void Save();
        //bool IsNull(StudentIspitDto obj);
    }
}
