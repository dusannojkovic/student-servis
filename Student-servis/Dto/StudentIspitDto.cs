using Student_servis.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Student_servis.Dto
{
    public class StudentIspitDto : IValidatableObject
    {
        public Student Student { get; set; }
        public Ispit Ispit { get; set; }
        [Required(ErrorMessage ="Morate izabrati studenta!")]
        public int idStudent { get; set; }
        [Required(ErrorMessage = "Morate izabrati ispit!")]
        public int idIspit { get; set; }
        [Required(ErrorMessage = "Unesite ocenu")]
        //[RegularExpression(@"^[1,0]{2}|[9,8,7,6,5]{1}$",
        //ErrorMessage = "Ocena nije u dobrom formatu")]
        public int Ocena { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            if (Ocena > 10 || Ocena < 5)
            {
                results.Add(new ValidationResult("Ocena mora biti u opsegu od 5 do 10"));
            }
            return results;

        }
    }
}