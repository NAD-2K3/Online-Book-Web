//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookStoreApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Comment
    {
        public int ID_Comment { get; set; }
        public System.DateTime Date { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        public int ID_Book { get; set; }
        public string User_Name { get; set; }
    
        public virtual Book Book { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
