//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace STO
{
    using System;
    using System.Collections.Generic;
    
    public partial class cDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cDetail()
        {
            this.vUsed_Detail = new HashSet<vUsed_Detail>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public int Available_Amount { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<vUsed_Detail> vUsed_Detail { get; set; }
    }
}
