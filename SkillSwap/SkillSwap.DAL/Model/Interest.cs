using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSwap.DAL.Model
{
    public class Interest
    {
        [Key]
        public Guid InterestID { get; set; }
        public string InterestName { get; set; } = string.Empty;
    }

}
