namespace SmartSchool.DataAccess.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Batch
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Batch()
        {
            Registrations = new HashSet<Registration>();
            StudentPrograms = new HashSet<StudentProgram>();
        }

        public int Id { get; set; }

        [StringLength(500)]
        public string Title { get; set; }

        public DateTime TimeFrom { get; set; }

        public DateTime TimeTo { get; set; }

        public bool IsActive { get; set; }

        public string Description { get; set; }

        public int? BatchCapacity { get; set; }

        public int SchoolId { get; set; }

        public bool OnSunday { get; set; }

        public bool OnMonday { get; set; }

        public bool OnTuesday { get; set; }

        public bool OnWednesday { get; set; }

        public bool OnThursday { get; set; }

        public bool OnFriday { get; set; }

        public bool OnSaturday { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Registration> Registrations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentProgram> StudentPrograms { get; set; }
    }
}
