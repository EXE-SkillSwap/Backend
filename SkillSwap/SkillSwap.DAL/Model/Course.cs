using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSwap.DAL.Model
{
    public class Course
    {
        [Key]
        public Guid CourseID { get; set; }
        public string? CourseName { get; set; }
        public string? CourseDetail { get; set; }
        public double CoursePrice { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("Material")]
        public Guid MaterialID { get; set; }
        public Material? Material { get; set; }
    }

}
