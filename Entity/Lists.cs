using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Trade.MvsWebUI.Entity
{
    public class Lists
    {
        public List<Product> PList { get; set; }

        public List<Category> cList{ get; set; }

        public Category Category { get; set; }
        public Product Product { get; set; }


    }
}