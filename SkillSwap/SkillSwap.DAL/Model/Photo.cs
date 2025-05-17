using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSwap.DAL.Model
{
    public class Photo
    {
        [Key]
        public Guid PhotoID { get; set; }

        [ForeignKey("UserAccount")]
        public Guid UserID { get; set; }

        public string URL { get; set; }
        public bool IsMain { get; set; }

        public UserAccount UserAccount { get; set; }
    }

}
