namespace Book.DL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Student")]
    public partial class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            StudentRegisters = new HashSet<StudentRegister>();
        }

        [Required]
        [StringLength(50)]
        public string FullName { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(30)]
        public string Email { get; set; }

        [StringLength(30)]
        public string DOB { get; set; }

        [StringLength(10)]
        public string Gender { get; set; }

        [StringLength(10)]
        public string Phone { get; set; }

        public int StudentID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentRegister> StudentRegisters { get; set; }
    }
}
