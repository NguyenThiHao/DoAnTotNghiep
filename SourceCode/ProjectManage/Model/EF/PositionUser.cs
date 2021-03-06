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

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime joinedDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? leaveDate { get; set; }

        
        [StringLength(50)]
        public string status { get; set; }

        public virtual Project Project { get; set; }

        public virtual User User { get; set; }

        public PositionUser(int _idUser, int _idProject)
        {
            this.idUser = _idUser;
            this.idProject = _idProject;
            this.position = "Admin";
            this.joinedDate = DateTime.Now;
            this.status = "Active";
        }
        public PositionUser()
        {
            this.joinedDate = DateTime.Now;
            this.status = "Active";
        }
    }
}
