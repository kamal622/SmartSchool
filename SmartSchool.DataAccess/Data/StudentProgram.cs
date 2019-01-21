namespace SmartSchool.DataAccess.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StudentProgram")]
    public partial class StudentProgram
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StudentProgram()
        {
            FeesDetails = new HashSet<FeesDetail>();
        }

        public int Id { get; set; }

        public int? StudentId { get; set; }

        public int? ProgramId { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? BatchId { get; set; }

        [StringLength(500)]
        public string Remarks { get; set; }

        public DateTime? AddedOn { get; set; }

        public double? TotalFees { get; set; }

        public int Duration { get; set; }

        public bool IsActive { get; set; }
        public DateTime? UpdatedOn { get; set; }
        

        public virtual Batch Batch { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FeesDetail> FeesDetails { get; set; }

        public virtual Program Program { get; set; }

        public virtual Student Student { get; set; }
    }
}
