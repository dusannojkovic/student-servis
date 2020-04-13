using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Student_servis.Dto
{
    public class IspitDto
    {
        public int idIspit { get; set; }
        [Required, RegularExpression(@"^([A-Z])\w+(\s[a-z]\w+)?$",
         ErrorMessage = "Naziv nije u dobrom formatu")]
        public string Naziv { get; set; }
        public System.DateTime Datum { get; set; }
        public int Aktivan { get; set; }

    }
}