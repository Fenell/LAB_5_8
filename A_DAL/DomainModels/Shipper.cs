using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace A_DAL.DomainModels
{
    public partial class Shipper
    {
        public Shipper()
        {
            Donhangs = new HashSet<Donhang>();
        }

        [Key]
        [Column("ShipperID")]
        public int ShipperId { get; set; }
        [StringLength(255)]
        public string? Hoten { get; set; }
        [StringLength(255)]
        public string? Sodienthoai { get; set; }

        [InverseProperty("Shipper")]
        public virtual ICollection<Donhang> Donhangs { get; set; }
    }
}
