using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NMS.Models
{
    [Table("Company")]
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int companyID { get; set; }
        [Required]
        public string companyName { get; set; }
        [Required]
        public string companyAddress { get; set; }
        public byte[] companyLogo { get; set; }
        [Required]
        public string companyPhone { get; set; }
        public string companyEmail { get; set; }
        [Required]
        public string companyDescription { get; set; }

    }
}