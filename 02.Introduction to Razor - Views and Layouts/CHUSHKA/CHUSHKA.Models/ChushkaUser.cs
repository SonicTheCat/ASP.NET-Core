namespace CHUSHKA.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;

    public class ChushkaUser : IdentityUser
    {
        public string FullName { get; set; }

        public IEnumerable<Order> Orders { get; set; } = new HashSet<Order>(); 
    }
}