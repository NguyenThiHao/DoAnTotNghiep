namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Phase")]
    public partial class Phase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Phase()
        {
            Sprints = new HashSet<Sprint>();
        }

        [Key]
        public int idPhase { get; set; }

        [Required]
        [StringLength(50)]
        public string phaseName { get; set; }

        [Required]
        public string description { get; set; }

        public int? idProject { get; set; }

        public DateTime startDate { get; set; }

        public DateTime endDate { get; set; }

        public long status { get; set; }

        public virtual Project Project { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sprint> Sprints { get; set; }
    }
}
