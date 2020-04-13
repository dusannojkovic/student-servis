using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Student_servis.Exceptions
{
    public class EntityAlreadyExistsException:Exception
    {
        public EntityAlreadyExistsException(string name) : base(name + "vec postoji.")
        {

        }
    }
}