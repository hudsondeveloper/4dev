namespace USM.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ROTA")]
    public partial class ROTA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ROTA()
        {
            ALUNO = new HashSet<ALUNO>();
            PONTOS_PARADA_CAMACARI = new HashSet<PONTOS_PARADA_CAMACARI>();
            PONTOS_PARADA_SALVADOR = new HashSet<PONTOS_PARADA_SALVADOR>();
        }

        [Key]
        public int ID_ROTA { get; set; }

        [Required]
        [StringLength(10)]
        public string NOME_ROTA { get; set; }

        [Required]
        [StringLength(7)]
        public string PLACA_ONIBUS { get; set; }

        public int MATRICULA_MOTORISTA { get; set; }

        public int ID_TURNO_ROTA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ALUNO> ALUNO { get; set; }

        public virtual MOTORISTA MOTORISTA { get; set; }

        public virtual ONIBUS ONIBUS { get; set; }

        public virtual TURNO TURNO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PONTOS_PARADA_CAMACARI> PONTOS_PARADA_CAMACARI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PONTOS_PARADA_SALVADOR> PONTOS_PARADA_SALVADOR { get; set; }
    }
}
