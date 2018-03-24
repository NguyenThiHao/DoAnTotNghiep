namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PositionUser")]
    public partial class PositionUser
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idUser { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idProject { get; set; }

        [Required]
        [StringLength(50)]
        public string position { get; set; }

        public DateTime joinedDate { get; set; }

        public DateTime? leaveDate { get; set; }

        public long status { get; set; }

        public virtual Project Project { get; set; }

        public virtual User User { get; set; }
    }
}
