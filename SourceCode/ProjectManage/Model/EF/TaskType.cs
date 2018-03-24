namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaskType")]
    public partial class TaskType
    {
        [Key]
        public int id_task_type { get; set; }

        [Required]
        [StringLength(50)]
        public string name_task_type { get; set; }

        [StringLength(500)]
        public string description { get; set; }
    }
}
