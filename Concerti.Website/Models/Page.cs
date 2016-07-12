//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Concerti.Website.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Page
    {
        public int PageId { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }
        public bool IsActive { get; set; }
        public bool DisplayTitle { get; set; }
        public System.DateTime DateCreated { get; set; }
        public int CreatedBy { get; set; }
        public Nullable<System.DateTime> DateLastUpdated { get; set; }
        public Nullable<int> LastUpdatedBy { get; set; }
    
        public virtual User CreatedByUser { get; set; }
        public virtual User LastUpdatedByUser { get; set; }
    }
}
