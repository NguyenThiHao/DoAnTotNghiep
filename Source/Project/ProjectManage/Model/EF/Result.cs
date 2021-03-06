namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Result")]
    public partial class Result
    {
        [Key]
        [Column(Order = 0)]
        public DateTime date { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idTask { get; set; }

        [StringLength(200)]
        public string link { get; set; }

        [Required]
        public string description { get; set; }

        [Required]
        [StringLength(250)]
        public string summary { get; set; }

        public double resultToday { get; set; }

        public double total { get; set; }

        public virtual Task Task { get; set; }
    }
}
