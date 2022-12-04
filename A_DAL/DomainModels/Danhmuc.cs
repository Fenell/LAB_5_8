using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace A_DAL.DomainModels
{
    [Table("Danhmuc")]
    public partial class Danhmuc
    {
        public Danhmuc()
        {
            Sanphams = new HashSet<Sanpham>();
        }

        [Key]
        [Column("DanhmucID")]
        public int DanhmucId { get; set; }
        [StringLength(255)]
        public string? TenDanhMuc { get; set; }
        [StringLength(255)]
        public string? MoTa { get; set; }

        [InverseProperty("Danhmuc")]
        public virtual ICollection<Sanpham> Sanphams { get; set; }
    }
}
