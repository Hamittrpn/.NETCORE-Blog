using System;
using System.ComponentModel.DataAnnotations;

namespace HamitTirpanBlog.Model.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        [Display(Name = "Oluşturulma tarihi")]
        public DateTime CreatedAt { get; set; }
        [Display(Name = "Oluşturan Kişi")]
        public string CreatedBy { get; set; }
        [Display(Name = "Güncelleme tarihi")]
        public DateTime UpdatedAt { get; set; }
        [Display(Name = "Güncelleyen Kişi")]
        public string UpdatedBy { get; set; }
        [Display(Name = "Aktif Mi?")]
        public bool IsActive { get; set; }
    }
}
