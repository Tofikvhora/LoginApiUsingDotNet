using System.ComponentModel.DataAnnotations;

namespace LoginApi.Models
{
  
    public class Users
    {
        [Key]
        public int UserId { get; set; } = 0;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public int IsActive { get; set; } = 1;

        public DateTime CreatedOn  { get; set; } = DateTime.Now;
    }

}
