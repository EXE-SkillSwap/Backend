using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSwap.DAL.Model
{
    public class CourseReview
    {
        [Key]
        public Guid CourseReviewID { get; set; }

        [ForeignKey("Course")]
        public Guid CourseID { get; set; }

        [ForeignKey("Review")]
        public Guid ReviewID { get; set; }

        public Course Course { get; set; }
        public Review Review { get; set; }
    }

}
