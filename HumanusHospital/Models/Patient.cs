using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HumanusHospital.Models
{
    public class Patient
    {
        [Key]
        public string PersonIDNr { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int Zipcode { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public enum Bloodtype
        {
            A_pos, A_neg, B_pos, B_neg, AB_pos, AB_neg, O_pos, O_neg
        }
        public virtual ICollection<Registration> Registrations { get; set; }
        public string Room { get; set; }


    }
}

