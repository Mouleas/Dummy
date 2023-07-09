using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class DeptModel
    {
        [Key] 
        public int DeptId { get; set; }

        public string DeptName { get; set; }

        public virtual ICollection<UserModel> Users { get; set; }
    }
}
