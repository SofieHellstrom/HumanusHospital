using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HumanusHospital.Models
{
    public class Registration
    {
        public int RegistrationID { get; set; }
        public string RoomID { get; set; }
        public string PatientPersonIDNr { get; set; } //Entity Framework interprets a property as a foreign key property if it's named <navigation property name><primary key property name>


        public virtual Room Room { get; set; }
        public virtual Patient Patient { get; set; }
    }
}