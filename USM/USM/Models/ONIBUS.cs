namespace USM.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ONIBUS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ONIBUS()
        {
            ROTA = new HashSet<ROTA>();
        }

        [Key]
        [StringLength(7)]
        public string PLACA { get; set; }

        [Required]
        [StringLength(30)]
        public string EMPRESA { get; set; }

        public int QTD_ASSENTOS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ROTA> ROTA { get; set; }
    }
}
