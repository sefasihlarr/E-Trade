//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace E_Trade.MvsWebUI.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class paketsiparis
    {
        public int Id { get; set; }
        public int musteriid { get; set; }
        public int adisyonid { get; set; }
        public int odemeturid { get; set; }
        public string aciklama { get; set; }
        public Nullable<bool> durum { get; set; }
    
        public virtual adisyonlar adisyonlar { get; set; }
        public virtual müsteriler müsteriler { get; set; }
        public virtual odemeturleri odemeturleri { get; set; }
    }
}