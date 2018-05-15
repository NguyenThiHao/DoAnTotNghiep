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

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime createdDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime due { get; set; }

        public double estimateTime { get; set; }

        [Required]
        public string description { get; set; }

        [Required]
        [StringLength(50)]
        public string type { get; set; }

        [StringLength(50)]
        public string status { get; set; }

        [Required]
        [StringLength(50)]
        public string priority { get; set; }

        public int assignee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Result> Results { get; set; }

        public virtual Sprint Sprint { get; set; }

        public virtual User User { get; set; }
    }
}
