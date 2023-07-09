using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }

        public string UserName { get; set; }

        [ForeignKey("Dept")]
        public int DeptId { get; set; }

        public virtual DeptModel Dept { get; set; }
    }
}
