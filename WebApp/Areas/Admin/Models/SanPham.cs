using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Areas.Admin.Models
{
    public class SanPham
    {
        [Key]
        public int MaSP { get; set; }

        [RegularExpression(@"^[0-9]{3}-[0-9]{3}[0-9]{3}$")]
        [Display(Name = "Số Serial Number")]
        [Required]
        [StringLength(20)]
        [Column(TypeName = "varchar(20)")]
        public string SN { get; set; }

        [StringLength(100, MinimumLength = 5)]
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string TenSP { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:dd-MM--yyyy}", ApplyFormatInEditMode =true)]
        public DateTime NgaySX { get; set; }
        [StringLength(255)]
        [Column(TypeName ="nvarchar(255)")]
        public string MoTa { get; set; }
        [Range(1000,1000000)]
       [DataType(DataType.Currency)]
       [Column(TypeName ="decimal(18,2)")]
       public decimal Gia { get; set; }

        public string Hinh { get; set; }

        public int TrangThai { get; set; }
        [ForeignKey("LoaiSP")]
        public LoaiSP LSP { get; set; }
    }
}
