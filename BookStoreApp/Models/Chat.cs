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
    
    public partial class Chat
    {
        public int Chat_ID { get; set; }
        public string Content { get; set; }
        public int IsSenderReaded { get; set; }
        public int IsRecieverReaded { get; set; }
        public string User_Name { get; set; }
    
        public virtual Customer Customer { get; set; }
    }
}
