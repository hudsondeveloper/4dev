namespace USM.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PONTOS_PARADA_SALVADOR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PONTOS_PARADA_SALVADOR()
        {
            ROTA = new HashSet<ROTA>();
        }

        [Key]
        public int ID_PONTO_SALVADOR { get; set; }

        [Required]
        [StringLength(30)]
        public string NOME_PONTO_PARADA_SALVADOR { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ROTA> ROTA { get; set; }
    }
}
