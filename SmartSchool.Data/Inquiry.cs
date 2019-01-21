//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SmartSchool.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Inquiry
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Nullable<int> StudentId { get; set; }
        public string Description { get; set; }
        public Nullable<int> InterestedIn { get; set; }
        public Nullable<int> OtherInterest { get; set; }
        public Nullable<System.DateTime> CanJoinFrom { get; set; }
        public Nullable<System.DateTime> InquiryDate { get; set; }
        public string Remarks { get; set; }
    
        public virtual Program Program { get; set; }
        public virtual Program Program1 { get; set; }
        public virtual Student Student { get; set; }
    }
}