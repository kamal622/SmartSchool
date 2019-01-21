namespace SmartSchool.DataAccess.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Registration")]
    public partial class Registration
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public DateTime RegisteredOn { get; set; }

        [StringLength(128)]
        public string RegisteredBy { get; set; }

        public int? ProgramId { get; set; }

        public int? Duration { get; set; }

        public DateTime? StratFrom { get; set; }

        public DateTime? ValidTill { get; set; }

        public decimal? TotalFees { get; set; }

        public decimal? FeesPaid { get; set; }

        [StringLength(500)]
        public string Remarks { get; set; }

        public bool IsActive { get; set; }

        public int? BatchId { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public virtual Batch Batch { get; set; }

        public virtual Program Program { get; set; }

        public virtual Student Student { get; set; }
    }
}
