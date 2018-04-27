using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.EF
{
    [Table("Role")]
    public class Role
    {
        [Key]
        [StringLength(20)]
        public string id { get; set; }

        [StringLength(50)]
        public string name { get; set; }
    }
}
