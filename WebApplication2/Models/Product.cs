using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    [Table("tblProducts")]
    public class Product
    {
        [Key]
        public int ProductCode { get; set; }
        [Column("Name")]
        public string ProductName { get; set; }
        [Column(Order = 1)]
        [Required]
        public int Price { get; set; }
        public int Quantity { get; set; }

        // Add foreign key

        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }



    }
}