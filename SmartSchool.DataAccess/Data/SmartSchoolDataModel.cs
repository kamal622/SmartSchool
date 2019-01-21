namespace SmartSchool.DataAccess.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SmartSchoolDataModel : DbContext
    {
        public SmartSchoolDataModel()
            : base("name=SmartSchoolDataModel")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Batch> Batches { get; set; }
        public virtual DbSet<DurationType> DurationTypes { get; set; }
        public virtual DbSet<FeesDetail> FeesDetails { get; set; }
        public virtual DbSet<Inquiry> Inquiries { get; set; }
        public virtual DbSet<Program> Programs { get; set; }
        public virtual DbSet<Registration> Registrations { get; set; }
        public virtual DbSet<School> Schools { get; set; }
        public virtual DbSet<SchoolType> SchoolTypes { get; set; }
        public virtual DbSet<StudentProgram> StudentPrograms { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Registrations)
                .WithOptional(e => e.AspNetUser)
                .HasForeignKey(e => e.RegisteredBy);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Students)
                .WithOptional(e => e.AspNetUser)
                .HasForeignKey(e => e.AddedBy);

            modelBuilder.Entity<Batch>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Batch>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<DurationType>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<DurationType>()
                .Property(e => e.Detail)
                .IsUnicode(false);

            modelBuilder.Entity<FeesDetail>()
                .Property(e => e.PaymentMode)
                .IsUnicode(false);

            modelBuilder.Entity<FeesDetail>()
                .Property(e => e.ChequeNo)
                .IsUnicode(false);

            modelBuilder.Entity<FeesDetail>()
                .Property(e => e.Remarks)
                .IsUnicode(false);

            modelBuilder.Entity<FeesDetail>()
                .Property(e => e.ReceivedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Inquiry>()
                .Property(e => e.Remarks)
                .IsUnicode(false);

            modelBuilder.Entity<Inquiry>()
                .Property(e => e.PreferredTiming)
                .IsUnicode(false);

            modelBuilder.Entity<Program>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Program>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Registration>()
                .Property(e => e.TotalFees)
                .HasPrecision(16, 2);

            modelBuilder.Entity<Registration>()
                .Property(e => e.FeesPaid)
                .HasPrecision(16, 2);

            modelBuilder.Entity<Registration>()
                .Property(e => e.Remarks)
                .IsUnicode(false);

            modelBuilder.Entity<School>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<School>()
                .Property(e => e.Owner)
                .IsUnicode(false);

            modelBuilder.Entity<School>()
                .Property(e => e.MobileNo)
                .IsUnicode(false);

            modelBuilder.Entity<School>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<School>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolType>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolType>()
                .HasMany(e => e.Schools)
                .WithOptional(e => e.SchoolType)
                .HasForeignKey(e => e.TypeId);

            modelBuilder.Entity<StudentProgram>()
                .Property(e => e.Remarks)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.MiddleName)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.CurrentAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Pincode)
                .IsFixedLength();

            modelBuilder.Entity<Student>()
                .Property(e => e.Mobile)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.School)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.SchoolAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.College)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.CollegeAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.ContactPersonName)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.ContactPersonPhone)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.ContactPersonRelationship)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.ImageName)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Inquiries)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Registrations)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);
        }
    }
}
