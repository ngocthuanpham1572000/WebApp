using System.ComponentModel.DataAnnotations;

namespace WebApp.Areas.Admin.Models
{
    public class LoaiSP
    {
        [Key]
        public int MaLoai { get; set; }
        [Display(Name ="Tên loại sản phẩm")]
        [StringLength(50,MinimumLength =3)]
        [Required]
        public string TenLoai { get; set; }
        public bool TrangThai { get; set; }
    }
}