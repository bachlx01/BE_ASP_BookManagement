namespace Book.DL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DM_BOOKS
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string BookId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(200)]
        public string Name { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(100)]
        public string Editor { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short Fiction { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(100)]
        public string Type { get; set; }

        [Key]
        [Column(Order = 5, TypeName = "money")]
        public decimal Price { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Release_Year { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(200)]
        public string Creator { get; set; }
    }
}
