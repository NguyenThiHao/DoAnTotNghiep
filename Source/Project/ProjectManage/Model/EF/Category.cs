namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        [Key]
        public int id_category { get; set; }

        [Required]
        [StringLength(50)]
        public string name_category { get; set; }

        public bool status { get; set; }

        [Required]
        [StringLength(200)]
        public string link { get; set; }
    }
}
