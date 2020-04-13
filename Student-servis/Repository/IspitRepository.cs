using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Student_servis.Models;
using Student_servis.Dto;
using Student_servis.Exceptions;

namespace Student_servis.Repository
{
    public class IspitRepository : IIspitRepository
    {

        private ServisEntities dbContext;

        public IspitRepository()
        {
            dbContext = new ServisEntities();

        }

        public IspitRepository(ServisEntities dbContext)
        {
            dbContext = this.dbContext;
        }

        public void Add(IspitDto obj)
        {
            
            dbContext.Ispits.Add(new Ispit {
                Naziv = obj.Naziv,
                Datum = obj.Datum,
                Aktivan = 1
            });
        }

        public void Delete(int ispitId)
        {
            var ispitJedan = dbContext.Ispits.Find(ispitId);
            if(ispitJedan == null)
            {
                throw new EntityNotFoundException("Ispit ");
            }
            ispitJedan.Aktivan = 0;

        }

        public IEnumerable<Ispit> GetAll()
        {
            return dbContext.Ispits.Where(x => x.Aktivan == 1);
        }

        public IspitDto GetbyId(int ispitId)
        {
            var find = dbContext.Ispits.Find(ispitId);
            if(find == null)
            {
                throw new EntityNotFoundException("Ispit ");
            }

            return new IspitDto
            {
                idIspit = find.idIspit,
                Naziv = find.Naziv,
                Datum = find.Datum,
                Aktivan = find.Aktivan
            };
        }

        public bool IsExist(IspitDto obj)
        {
            if (dbContext.Ispits.Any(i => i.Naziv  == obj.Naziv))
            {
                return true;
            }
            return false;
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        public void Update(int id,IspitDto obj)
        {
            var ispit = dbContext.Ispits.Find(id);
            if(ispit == null)
            {
                throw new EntityNotFoundException("Ispit ");
            }
            
            ispit.Naziv = obj.Naziv;
            ispit.Datum = obj.Datum;
        }
    }
}