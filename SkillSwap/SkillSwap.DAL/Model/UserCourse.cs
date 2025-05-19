using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSwap.DAL.Model
{
    public class UserCourse
    {
        [Key]
        public Guid UserCourseID { get; set; }

        [ForeignKey("UserAccount")]
        public Guid UserID { get; set; }

        [ForeignKey("Course")]
        public Guid CourseID { get; set; }

        public UserAccount? UserAccount { get; set; }
        public Course? Course { get; set; }
    }

}
