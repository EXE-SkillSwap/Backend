using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSwap.DAL.Model
{
    public class Review
    {
        [Key]
        public Guid ReviewID { get; set; }
        public string ReviewDetail { get; set; }
        public double Rating { get; set; }
        public DateTime CreatedDate { get; set; }
    }

}
