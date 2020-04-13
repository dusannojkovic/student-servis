using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Student_servis.Dto
{
    public class StudentDto 
    {
        public int idStudent { get; set; }
        [Required,RegularExpression(@"^[A-Z][a-z]{2,15}$",
         ErrorMessage = "Ime nije u dobrom formatu")]
        public string Ime { get; set; }
        [Required, RegularExpression(@"^([A-Z])\w+(\s[A-Z]\w+)?$",
         ErrorMessage = "Prezime nije u dobrom formatu")]
        public string Prezime { get; set; }
        [Required, RegularExpression(@"([A-Z])\w*(\s[A-Z]\w*)?\s([1-9]{1,3})(\w)?$",
         ErrorMessage = "Adresa nije u dobrom formatu")]
        public string Adresa { get; set; }
        public System.DateTime Datum_rodjenja { get; set; }
        [Required, RegularExpression(@"([1-9]([0-9])*\/[0-9][0-9])$",
        ErrorMessage = "Indeks nije u dobrom formatu")]
        public string Broj_indeks { get; set; }
        public int Aktivan { get; set; }

     
    }
}

