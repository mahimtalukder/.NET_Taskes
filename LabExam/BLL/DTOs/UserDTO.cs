using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Uname { get; set; }
        [Required]
        [StringLength(10)]
        public string Password { get; set; }
        [Required]
        public int Type { get; set; }
    }
}
