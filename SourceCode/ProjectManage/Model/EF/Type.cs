namespace Model.EF
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Type")]
    public partial class Type
    {
        [Key]
        public int idType { get; set; }

        [Required]
        [StringLength(50)]
        public string typeName { get; set; }

        public string description { get; set; }

        public string table { get; set; }
    }
}
