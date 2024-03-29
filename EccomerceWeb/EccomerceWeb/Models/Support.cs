//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EccomerceWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Support
    {
        public int SupportID { get; set; }
        public int AssociateID { get; set; }
        public int TopicID { get; set; }
        public string Description { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string Status { get; set; }
        public System.DateTime DateReceived { get; set; }
        public Nullable<System.DateTime> DateSolved { get; set; }
    
        public virtual Associate Associate { get; set; }
        public virtual User User { get; set; }
        public virtual SupportTopic SupportTopic { get; set; }
    }
}
