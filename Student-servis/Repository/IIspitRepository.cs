using Student_servis.Dto;
using Student_servis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_servis.Repository
{
    public interface IIspitRepository
    {
        IEnumerable<Ispit> GetAll();
        IspitDto GetbyId(int ispitId);
        void Add(IspitDto obj);
        void Update(int ispitId,IspitDto obj);
        void Delete(int ispitId);
        void Save();
        bool IsExist(IspitDto obj);
    }
}
