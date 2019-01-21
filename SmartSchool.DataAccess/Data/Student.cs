namespace SmartSchool.DataAccess.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            Inquiries = new HashSet<Inquiry>();
            Registrations = new HashSet<Registration>();
            StudentPrograms = new HashSet<StudentProgram>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Please Fill FirstName.")]
        [StringLength(250)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(250)]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(250)]
        public string LastName { get; set; }

        [StringLength(500)]
        public string CurrentAddress { get; set; }

        [StringLength(10)]
        public string Pincode { get; set; }

        [StringLength(50)]
        public string Mobile { get; set; }

        public DateTime? DOB { get; set; }

        [StringLength(500)]
        public string Email { get; set; }

        [StringLength(250)]
        public string School { get; set; }

        [StringLength(500)]
        public string SchoolAddress { get; set; }

        [StringLength(250)]
        public string College { get; set; }

        [StringLength(500)]
        public string CollegeAddress { get; set; }

        [StringLength(500)]
        public string ContactPersonName { get; set; }

        [StringLength(50)]
        public string ContactPersonPhone { get; set; }

        [StringLength(250)]
        public string ContactPersonRelationship { get; set; }

        public bool HasPhoto { get; set; }

        public bool IsRegistered { get; set; }

        public bool IsActive { get; set; }

        public DateTime? AddedOn { get; set; }

        [StringLength(128)]
        public string AddedBy { get; set; }

        [StringLength(500)]
        public string City { get; set; }

        [StringLength(150)]
        public string ImageName { get; set; }

        public DateTime? RegistrationDate { get; set; }
        public DateTime? UpdatedOn { get; set; }

        [StringLength(128)]
        public string UpdatedBy { get; set; }

        public string RegistrationNo { get; set; }
        
        public virtual AspNetUser AspNetUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inquiry> Inquiries { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Registration> Registrations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentProgram> StudentPrograms { get; set; }
    }
}
