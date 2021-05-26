namespace Book.DL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StudentRegister")]
    public partial class StudentRegister
    {
        public int ID { get; set; }

        public int? StudentID { get; set; }

        public int? CourseID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? RegisterDate { get; set; }

        public virtual Course Course { get; set; }

        public virtual Student Student { get; set; }
    }
}
