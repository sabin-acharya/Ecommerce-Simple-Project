using Microsoft.AspNetCore.Identity;

namespace Shopping.Data
{
    //CustomUser

    public class ApplicationUser : IdentityUser
    {
      
        public string? FirstName { get; set;}

        public string? Address { get; set;}
        public string? LastName { get; set;}
        

    }
}
