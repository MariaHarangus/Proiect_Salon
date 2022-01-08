namespace SalonCModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Servicii")]
    public partial class Servicii
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Servicii()
        {
            Programares = new HashSet<Programare>();
        }

        [Key]
        public int Id_Serviciu { get; set; }

        [Required]
        [StringLength(50)]
        public string Tip_Serviciu { get; set; }

        public int Pret { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Programare> Programares { get; set; }
    }
}
