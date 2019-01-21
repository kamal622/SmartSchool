namespace SmartSchool.DataAccess.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class School
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public School()
        {
            DurationTypes = new HashSet<DurationType>();
            Programs = new HashSet<Program>();
        }

        public int Id { get; set; }

        [StringLength(500)]
        public string Name { get; set; }

        public int? TypeId { get; set; }

        [StringLength(250)]
        public string Owner { get; set; }

        [StringLength(50)]
        public string MobileNo { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        public string Description { get; set; }

        public int? StudentStrength { get; set; }

        public DateTime? RegisteredOn { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DurationType> DurationTypes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Program> Programs { get; set; }

        public virtual SchoolType SchoolType { get; set; }
    }
}
