using System;
using System.Collections.Generic;

namespace EFCoreSPAPI.Models
{
    public partial class ProductMaster
    {
        public int Id { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public int Price { get; set; }
    }
}
