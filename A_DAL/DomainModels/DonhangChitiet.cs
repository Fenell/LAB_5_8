using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace A_DAL.DomainModels
{
    [Table("DonhangChitiet")]
    public partial class DonhangChitiet
    {
        [Key]
        [Column("DonhangChitietID")]
        public int DonhangChitietId { get; set; }
        [Column("DonhangID")]
        public int? DonhangId { get; set; }
        [Column("SanphamID")]
        public int? SanphamId { get; set; }
        public int? Soluong { get; set; }

        [ForeignKey("DonhangId")]
        [InverseProperty("DonhangChitiets")]
        public virtual Donhang? Donhang { get; set; }
        [ForeignKey("SanphamId")]
        [InverseProperty("DonhangChitiets")]
        public virtual Sanpham? Sanpham { get; set; }
    }
}
