using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSwap.DAL.Model
{
    public class Category
    {
        [Key]
        public Guid CategoryID { get; set; } = Guid.NewGuid();
        [Required]
        public string CategoryName { get; set; }
        [ForeignKey("Course")]
        public Guid CourseID { get; set; }
        public Course? Course { get; set; }
    }

}
