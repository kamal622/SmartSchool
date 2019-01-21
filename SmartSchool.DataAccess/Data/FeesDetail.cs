namespace SmartSchool.DataAccess.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FeesDetail
    {
        public int Id { get; set; }

        public int? StudentProgramId { get; set; }

        public int? FeesPaid { get; set; }

        public DateTime? PaidOn { get; set; }

        [StringLength(500)]
        public string PaymentMode { get; set; }

        [StringLength(50)]
        public string ChequeNo { get; set; }

        [StringLength(500)]
        public string Remarks { get; set; }

        [StringLength(150)]
        public string ReceivedBy { get; set; }

        public int Duration { get; set; }
        public DateTime? ValidTill { get; set; }
        
        public virtual StudentProgram StudentProgram { get; set; }
    }
}
