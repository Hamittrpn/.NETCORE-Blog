using System;
using System.ComponentModel.DataAnnotations;

namespace HamitTirpanBlog.Model.Entities
{
    public class Feedback:BaseEntity
    {
        [Display(Name = "Ad-Soyad")]
        public string Name { get; set; }
        [Display(Name = "E-posta")]
        public string Email { get; set; }
        [Display(Name = "Konu")]
        public string Subject { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Mesaj")]
        public string Message { get; set; }
    }
}
