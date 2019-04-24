using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace HamitTirpanBlog.Model.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Resim")]
        public string Photo { get; set; }
        [Display(Name = "isim")]
        public string FirstName { get; set; }
        [Display(Name = "Soyisim")]
        public string LastName { get; set; }
    }
}
