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
    
    public partial class müsteriler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public müsteriler()
        {
            this.paketsiparis = new HashSet<paketsiparis>();
        }
    
        public int Id { get; set; }
        public string ad { get; set; }
        public string soyad { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<paketsiparis> paketsiparis { get; set; }
    }
}
