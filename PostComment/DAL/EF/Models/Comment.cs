using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public string CommentText{ get; set; }
        public int PostId { get; set; }

        public virtual Post post { get; set; }


    }
}
