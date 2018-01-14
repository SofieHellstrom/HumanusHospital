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
        [Required]
        [RegularExpression(@"^(19|20)?[0-9]{2}[- ]?((0[0-9])|(10|11|12))[- ]?(([0-2][0-9])|(3[0-1])|(([7-8][0-9])|(6[1-9])|(9[0-1])))[- ]?[0-9]{4}$", ErrorMessage = "Please enter a personal ID number in YYYYMMDD-XXXX format.")]
        [ Display(Name = "Personal ID Number")]
        public string PersonIDNr { get; set; }

        [Required]
        [RegularExpression(@"^[A-ZÅÄÖ]+[a-zåäöA-ZÅÄÖ''-'\s\-]*$", ErrorMessage = "Please enter a valid name.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression(@"^[A-ZÅÄÖ]+[a-zåäöA-ZÅÄÖ''-'\s\-]*$", ErrorMessage = "Please enter a valid name.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        public string Address { get; set; }
        public int Zipcode { get; set; }

        [RegularExpression(@"^[A-ZÅÄÖ]+[a-zåäöA-ZÅÄÖ''-'\s\-]*$")]
        public string City { get; set; }
        public string Phone { get; set; }

        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$")]
        public string Email { get; set; }
        public string Bloodtype { get; set; }

        public virtual ICollection<Registration> Registrations { get; set; }

        public string RoomID { get; set; }

        [ForeignKey("RoomID")]
        public virtual Room Room { get; set; }


    }
}

