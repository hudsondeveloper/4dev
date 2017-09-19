namespace USM.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PONTOS_PARADA_CAMACARI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PONTOS_PARADA_CAMACARI()
        {
            ROTA = new HashSet<ROTA>();
        }

        [Key]
        public int ID_PONTO_CAMACARI { get; set; }

        [Required]
        [StringLength(30)]
        public string NOME_PONTO_PARADA_CAMACARI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ROTA> ROTA { get; set; }
    }
}
