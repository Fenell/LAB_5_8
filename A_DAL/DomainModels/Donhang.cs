using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace A_DAL.DomainModels
{
    [Table("Donhang")]
    public partial class Donhang
    {
        public Donhang()
        {
            DonhangChitiets = new HashSet<DonhangChitiet>();
        }

        [Key]
        [Column("DonhangID")]
        public int DonhangId { get; set; }
        [Column("KhachhangID")]
        public int? KhachhangId { get; set; }
        [Column("NhanvienID")]
        public int? NhanvienId { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Ngaydathang { get; set; }
        [Column("ShipperID")]
        public int? ShipperId { get; set; }

        [ForeignKey("KhachhangId")]
        [InverseProperty("Donhangs")]
        public virtual Khachhang? Khachhang { get; set; }
        [ForeignKey("NhanvienId")]
        [InverseProperty("Donhangs")]
        public virtual Nhanvien? Nhanvien { get; set; }
        [ForeignKey("ShipperId")]
        [InverseProperty("Donhangs")]
        public virtual Shipper? Shipper { get; set; }
        [InverseProperty("Donhang")]
        public virtual ICollection<DonhangChitiet> DonhangChitiets { get; set; }
    }
}
