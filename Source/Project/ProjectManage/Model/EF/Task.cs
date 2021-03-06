namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Task")]
    public partial class Task
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Task()
        {
            Results = new HashSet<Result>();
        }

        [Key]
        public int idTask { get; set; }

        [Required]
        [StringLength(50)]
        public string taskName { get; set; }

        [Required]
        [StringLength(200)]
        public string summary { get; set; }

        public int idSprint { get; set; }

        public DateTime createdDate { get; set; }

        public DateTime due { get; set; }

        public int estimateTime { get; set; }

        [Required]
        public string description { get; set; }

        public int type { get; set; }

        public int status { get; set; }

        public int priority { get; set; }

        public int assignee { get; set; }

        public string comment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Result> Results { get; set; }

        public virtual Sprint Sprint { get; set; }
    }
}
