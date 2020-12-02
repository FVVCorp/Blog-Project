using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {
        /// <summary>
        /// First name of the user
        /// </summary>
        [Required]
        public string FirstName { get; set; }
        /// <summary>
        /// Last name of the user
        /// </summary>
        [Required]
        public string LastName { get; set; }
    }
}