//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UniversiteOtomasyon.DataEntities
{
    using System;
    using System.Collections.Generic;
    
    public partial class EPIDOSE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EPIDOSE()
        {
            this.LESSONTb = new HashSet<LESSONTb>();
            this.UserDetails = new HashSet<UserDetails>();
        }
    
        public int ID { get; set; }
        public string EPIDOSENAME { get; set; }
        public Nullable<int> FACULTYID { get; set; }
    
        public virtual FACULTY FACULTY { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LESSONTb> LESSONTb { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserDetails> UserDetails { get; set; }
    }
}