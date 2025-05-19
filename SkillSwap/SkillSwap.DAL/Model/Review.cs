using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSwap.DAL.Model
{
    public class Review
    {
        [Key]
        public Guid ReviewID { get; set; } = Guid.NewGuid();
        public string ReviewDetail { get; set; } = null!;
        public double? Rating { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [ForeignKey("Order")]
        public Guid? OrderID { get; set; }
        public Order? Order { get; set; }

    }

}