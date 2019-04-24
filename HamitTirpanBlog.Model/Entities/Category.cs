using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HamitTirpanBlog.Model.Entities
{
    public class Category:BaseEntity
    {
        public Category()
        {
            Posts = new HashSet<Post>();
        }
        [Required]
        [Display(Name = "Kategori Adı")]
        public string Name { get; set; }
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
