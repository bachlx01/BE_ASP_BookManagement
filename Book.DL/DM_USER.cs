using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.DL
{
    public partial class DM_USER
    {
        [Key]
        [StringLength(50)]
        public string USER_ID { get; set; }

        [StringLength(100)]
        public string USER_NAME { get; set; }

        [StringLength(50)]
        public string USER_LOGIN { get; set; }

        [StringLength(50)]
        public string PASSWORD { get; set; }

        [StringLength(200)]
        public string FULL_NAME { get; set; }

        [Column(TypeName = "date")]
        public DateTime BIRTH_DAY { get; set; }

        [StringLength(50)]
        public string GENDER { get; set; }

        public int MOBILE { get; set; }

        [StringLength(200)]
        public string ADDRESS { get; set; }

        [StringLength(100)]
        public string EMAIL { get; set; }

        [StringLength(50)]
        public string CMTNN { get; set; }

        [StringLength(100)]
        public string PERMISSION { get; set; }

    }
}
