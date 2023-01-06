using Microsoft.AspNetCore.Mvc.Rendering;

namespace LaFiesta.ViewModels
{
    public class GrantPermissionsViewModel
    {
        public SelectList Users { get; set; }
        public SelectList Roles { get; set; }
        public string UserId { get; set; }
        public string RoleId { get; set; }
    }
}
