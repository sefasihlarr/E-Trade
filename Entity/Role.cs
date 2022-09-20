using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Trade.MvsWebUI.Entity
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<User> Users { get; set; }


    }
}