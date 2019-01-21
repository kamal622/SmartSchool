namespace SmartSchool.DataAccess.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Inquiry")]
    public partial class Inquiry
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public bool IsInterestedInGuitar { get; set; }

        public bool IsInterestedInKeyBoard { get; set; }

        public bool IsInterestedInBass { get; set; }

        public bool IsInterestedInDrums { get; set; }

        public bool IsInterestedInVocals { get; set; }

        public bool IsInterestedInRecording { get; set; }

        public string Remarks { get; set; }

        public DateTime InquiryDate { get; set; }

        [StringLength(250)]
        public string PreferredTiming { get; set; }

        public bool? IsEvening { get; set; }

        public bool? IsMorning { get; set; }

        public virtual Student Student { get; set; }
    }
}
