using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.EF
{
    [Table("Credential")]
    [Serializable]
    public class Credential
    {
        [Key]
        [StringLength(20)]
        public string idUserGroup { get; set; }

        [StringLength(50)]
        public string idRole { get; set; }
    }
}
