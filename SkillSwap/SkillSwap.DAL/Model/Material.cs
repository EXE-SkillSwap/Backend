using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSwap.DAL.Model
{
    public class Material
    {
        [Key]
        public Guid MaterialID { get; set; }
        public string MaterialName { get; set; } = null!;
        public string? Quiz { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? Video { get; set; }
    }

}
