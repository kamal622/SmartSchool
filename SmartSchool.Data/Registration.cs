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
    
    public partial class Registration
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int ProgramId { get; set; }
        public System.DateTime RegisteredOn { get; set; }
        public System.DateTime ValidUpto { get; set; }
        public string Remarks { get; set; }
        public string RegisteredBy { get; set; }
        public string RegistrationNo { get; set; }
        public Nullable<int> DurationTypeId { get; set; }
        public Nullable<int> SchoolId { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual DurationType DurationType { get; set; }
        public virtual Program Program { get; set; }
        public virtual School School { get; set; }
        public virtual Student Student { get; set; }
    }
}
