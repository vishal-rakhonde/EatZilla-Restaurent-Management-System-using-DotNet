/*using System.ComponentModel.DataAnnotations;

namespace EatZilla.Models.CoreClasses
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Full name is required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Full name must be between 3 and 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mobile number is required")]
        [RegularExpression(@"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$", ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long")]
        public string Password { get; set; }

        public User(int id, string name, string email, string phone, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Phone = phone;
            Password = password;
        }
    }
}

*/

/*
using System.ComponentModel.DataAnnotations;

namespace EatZilla.Models.CoreClasses
{
    public class User
    {
        public User()
        {
        }

        *//* [Key]
public int Id { get; set; }
[Required]
public string Name { get; set; }
[Required]
public string Email { get; set; }
[Required]
public string Password { get; set; }
public User()
{

}
public User(int id,string name,string email,string password)
{
    Id = id;
    Name = name;
    Email = email;
    Password = password;

}
    */
using System.ComponentModel.DataAnnotations;

namespace EatZilla.Models.CoreClasses
{
    public class User
    {
        public User()
        {
        }
        public int Id { get; set; }

        [Required(ErrorMessage = "Full name is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Full name must be between 3 and 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Mobile number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        
        public string Phone { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long")]
        public string Password { get; set; }

        public Boolean isAdmin { get; set; }

        public User(int id, string name, string email, string phone, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Phone = phone;
            Password = password;
        }
    }
}
