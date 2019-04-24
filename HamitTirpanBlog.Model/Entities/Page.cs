using System;
using System.ComponentModel.DataAnnotations;

namespace HamitTirpanBlog.Model.Entities
{
    public class Page:BaseEntity
    {
        [Display(Name = "Başlık")]
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
    }
}
