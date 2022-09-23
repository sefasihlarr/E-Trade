using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Trade.MvsWebUI.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public bool IsApproved { get; set; }
        public int CategoryId { get; set; }
        public int Price { get; set; }
        public string PictureUrl { get; set; }

        public virtual Category Category { get; set; }
        
    }
}