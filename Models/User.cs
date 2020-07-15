using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NMS.Models
{[Table("User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userId { get; set; }
        

        public string email { get; set; }
        [Required]
        public string phone { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        public string designation { get; set; }
        public string description { get; set; }
        [Required]
        
        public string userName { get; set; }
        [Required]
        [MinLength(8)]
       
        public string password { get; set; }
        [Required]
        public int userTypeId { get; set; }
        
        [ForeignKey("userTypeId")]
        public UserCredential UserCredentials { get; set; }
        
       

    }
}