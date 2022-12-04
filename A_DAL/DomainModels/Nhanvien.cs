using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace A_DAL.DomainModels
{
    [Table("Nhanvien")]
    public partial class Nhanvien
    {
        public Nhanvien()
        {
            Donhangs = new HashSet<Donhang>();
        }

        [Key]
        [Column("NhanviennID")]
        public int NhanviennId { get; set; }
        [StringLength(255)]
        public string? Ten { get; set; }
        [StringLength(255)]
        public string? Ho { get; set; }
        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }
        [StringLength(255)]
        public string? Anh { get; set; }
        [Column(TypeName = "text")]
        public string? Ghichu { get; set; }

        [InverseProperty("Nhanvien")]
        public virtual ICollection<Donhang> Donhangs { get; set; }
    }
}
