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
    
    public partial class HireBookDetail
    {
        public int HireBookDetail_ID { get; set; }
        public int ID_Book { get; set; }
        public int ID_HireBook { get; set; }
    
        public virtual Book Book { get; set; }
        public virtual HireBook HireBook { get; set; }
    }
}