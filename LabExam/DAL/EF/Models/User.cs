using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL.EF.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Uname{ get; set; }
        [Required]
        [StringLength(10)]
        public string Password{ get; set; }
        [Required]
        public int Type { get; set; }
        public virtual List<Token> Tokens { get; set; }
        public User()
        {
            Tokens = new List<Token>();
        }

    }
}
