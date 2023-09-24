using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

public class ApplicationRole : IdentityRole
{
    public string? Role {  get; set; }

    public IEnumerable<SelectListItem> RolesList { get; set; }  
}
