namespace SalonCModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Programare")]
    public partial class Programare
    {
        public int Id { get; set; }

        public int? Id_Client { get; set; }

        public int? Id_Serviciu { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Data { get; set; }

        public DateTime? Ora { get; set; }

        public int Id_Angajat { get; set; }

        public virtual Angajati Angajati { get; set; }

        public virtual Clienti Clienti { get; set; }

        public virtual Servicii Servicii { get; set; }
    }
}
