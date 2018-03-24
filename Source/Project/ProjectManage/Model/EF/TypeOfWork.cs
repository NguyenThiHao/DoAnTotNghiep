namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TypeOfWork")]
    public partial class TypeOfWork
    {
        [Key]
        public int id_work_type { get; set; }

        [Required]
        [StringLength(100)]
        public string name_work_type { get; set; }

        [StringLength(200)]
        public string description { get; set; }
    }
}
