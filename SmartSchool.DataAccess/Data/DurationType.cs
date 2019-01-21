namespace SmartSchool.DataAccess.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DurationType
    {
        public int Id { get; set; }

        [StringLength(500)]
        public string Type { get; set; }

        public string Detail { get; set; }

        public int? SchoolId { get; set; }

        public virtual School School { get; set; }
    }
}
