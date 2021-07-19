using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace registration.Entities
{
    [Table("User")]
    public class Userdata
    {
        [Required]
        [Key , Column(Order =1)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string firstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string email { get; set; }
        [Required]
        [Phone]
        [Display(Name = "Contact Number")]
        public string contactNumber { get; set; }
        [Required]
        [Display(Name = "Gender")]
        public string gender { get; set; }
        [Required]
        [Display(Name = "Date Of Birth")]
        public DateTime dateOfBirth { get; set; }
        [Required]
        [Display(Name = "City")]
        public string city { get; set; }
        [Required]
        [Display(Name = "Photo")]
        public byte[] Image { get; set; }

        [NotMapped]
        public SelectList cityList { get; set; }

        //[NotMapped]
        //[Range(typeof(bool), "true", "true", ErrorMessage = "You accept terms and condition")]
        //public bool TermsAndConditions { get; set; }
    }
}