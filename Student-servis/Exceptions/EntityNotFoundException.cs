using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Student_servis.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string name) : base(name + "ne postoji.")
        {

        }
    }
}