using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Dao
{
    public class UserModelDao
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public int DeptId { get; set; }
    }
}
