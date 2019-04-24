using System;
using System.ComponentModel.DataAnnotations;

namespace HamitTirpanBlog.Model.Entities
{
    public class Post:BaseEntity
    {
        [Required]
        [Display(Name = "Başlık")]
        public string Title { get; set; }
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
        [Display(Name = "Resim")]
        public string Photo { get; set; }
        public Guid? CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
