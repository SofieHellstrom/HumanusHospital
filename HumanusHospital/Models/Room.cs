using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HumanusHospital.Models
{
    public class Room
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)] //this attribute lets you enter the primary key for the room rather than having the database generate it.
        public string RoomID { get; set; }
        public string Function { get; set; }
        //public enum Function { Patientroom, Lab, Examination, Administration } 
        public int Capacity { get; set; }
        public int Max_Capacity { get; set; }
        public string Department { get; set; }

        public virtual ICollection<Registration> Registrations { get; set; }
        public virtual ICollection<Patient> Patient { get; set; }
    }
}