namespace Toska.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();


        //Identity info
        public string FirstName { get; set; }
        public string LastName { get; set; }


        //Contact info
        public string Email { get; set; } = null!;


        //Security
        public string PasswordHash { get; set; } = null!;
        public string Role { get; set; } = "User";


        //Status
        public bool IsActive { get; set; } = true;


        //Audit
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }


    }
}
