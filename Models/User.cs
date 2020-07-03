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
        public string userName { get; set; }

        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string designation { get; set; }
        public string description { get; set; }
        public int userTypeId { get; set; }
        
        [ForeignKey("userTypeId")]
        public UserCredential UserCredentials { get; set; }
        
        public ICollection<Favourite> Favourites { get; set; }

    }
}