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
    
    public partial class ANNOUNCEMENTS
    {
        public int ID { get; set; }
        public string TITLE { get; set; }
        public string CONTENT { get; set; }
        public System.DateTime ANNOUNCEMENTSDATE { get; set; }
        public int USERID { get; set; }
        public Nullable<int> State { get; set; }
    
        public virtual USERS USERS { get; set; }
    }
}
