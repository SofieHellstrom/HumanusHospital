using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HumanusHospital.Models
{
    public class Room
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)] //this attribute lets you enter the primary key for the room rather than having the database generate it.
        [Display(Name = "Room Number")]
        public string RoomID { get; set; }
        public string Function { get; set; } 
        public int Capacity { get; set; }
        [Display(Name = "Maximum Capacity")]
        public int Max_Capacity { get; set; }
        public string Department { get; set; }

        public virtual ICollection<Registration> Registrations { get; set; }
        public virtual ICollection<Patient> Patient { get; set; }
    }
}