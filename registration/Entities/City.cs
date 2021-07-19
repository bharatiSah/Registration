using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace registration.Entities
{
    [Table("City")]
    public class City
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string city { get; set; }

    }
}