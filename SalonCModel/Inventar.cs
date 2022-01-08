namespace SalonCModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Inventar")]
    public partial class Inventar
    {
        [Key]
        public int Id_Produs { get; set; }

        [Required]
        [StringLength(50)]
        public string Nume_Produs { get; set; }

        public int Stoc_Curent { get; set; }

        public int Stoc_minim { get; set; }
    }
}
