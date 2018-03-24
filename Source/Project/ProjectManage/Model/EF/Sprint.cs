namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sprint")]
    public partial class Sprint
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sprint()
        {
            Tasks = new HashSet<Task>();
        }

        [Key]
        public int idSprint { get; set; }

        [Required]
        [StringLength(200)]
        public string sprintName { get; set; }

        public int idPhase { get; set; }

        public DateTime createdDate { get; set; }

        public int reporter { get; set; }

        [Required]
        public string description { get; set; }

        public int status { get; set; }

        public virtual Phase Phase { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
