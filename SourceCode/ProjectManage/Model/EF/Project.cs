namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Project")]
    public partial class Project
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Project()
        {
            Phases = new HashSet<Phase>();
            PositionUsers = new HashSet<PositionUser>();
        }

        [Key]
        public int idProject { get; set; }

        [Required]
        [StringLength(100)]
        public string projectName { get; set; }

        [Required]
        public string description { get; set; }

        public DateTime startDate { get; set; }

        public DateTime endDate { get; set; }

        [Required]
        [StringLength(50)]
        public string status { get; set; }

        [Required]
        [StringLength(50)]
        public string typeProject { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Phase> Phases { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PositionUser> PositionUsers { get; set; }
    }
}
