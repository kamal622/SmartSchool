namespace SmartSchool.DataAccess.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Program
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Program()
        {
            Registrations = new HashSet<Registration>();
            StudentPrograms = new HashSet<StudentProgram>();
        }

        public int Id { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsAvailable { get; set; }

        public int? TotalInstruments { get; set; }

        public int? TotalTeachers { get; set; }

        public int? TotalBatches { get; set; }

        public int? TotalstudentCapacityPerBatch { get; set; }

        public int? SchoolId { get; set; }

        public virtual School School { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Registration> Registrations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentProgram> StudentPrograms { get; set; }
    }
}
