using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NMS.Models
{
    [Table("userCridential")]
    public class UserCredential
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userTypeId { get; set; }
        public string userTypeName { get; set; }
        public ICollection<User> Users { get; set; }

    }
}