using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SkillSwap.DAL.Model
{
    public class OrderDetail
    {
        [Key]
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        [ForeignKey(nameof(CourseID))]
        public Guid CourseID { get; set; }
        public Course Course { get; set; }
        [ForeignKey(nameof(OrderId))]
        public Guid OrderId { get; set; }

        [JsonIgnore]
        public virtual Order Order { get; set; }
    }
}
