//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookStoreApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class HireBook
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HireBook()
        {
            this.HireBookDetails = new HashSet<HireBookDetail>();
        }
    
        public int ID_HireBook { get; set; }
        public int Confirm { get; set; }
        public Nullable<double> Total { get; set; }
        public System.DateTime Date_Start { get; set; }
        public System.DateTime Date_End { get; set; }
        public string User_Name { get; set; }
    
        public virtual Customer Customer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HireBookDetail> HireBookDetails { get; set; }
    }
}
