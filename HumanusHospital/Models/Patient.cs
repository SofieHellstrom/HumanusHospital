using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HumanusHospital.Models
{
    public class Patient
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public string PersonIDNr { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int Zipcode { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Bloodtype { get; set; }
        
        public virtual ICollection<Registration> Registrations { get; set; }
        public string Room { get; set; }


    }
}

