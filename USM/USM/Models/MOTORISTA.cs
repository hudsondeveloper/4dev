namespace USM.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MOTORISTA")]
    public partial class MOTORISTA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MOTORISTA()
        {
            ROTA = new HashSet<ROTA>();
        }

        [Key]
        public int MATRICULA { get; set; }

        [Required]
        [StringLength(70)]
        public string NOME_MOTORISTA { get; set; }

        public int CPF_MOTORISTA { get; set; }

        public int NUM_HABILITACAO { get; set; }

        [Column(TypeName = "date")]
        public DateTime DATA_NASC_MOTORISTA { get; set; }

        [Required]
        [StringLength(300)]
        public string ENDERECO_MOTORISTA { get; set; }

        [Required]
        [StringLength(15)]
        public string TELEFONE_MOTORISTA { get; set; }

        public int SEXO_ID { get; set; }

        public int ESTADO_CIVIL_ID { get; set; }

        public virtual ESTADO_CIVIL ESTADO_CIVIL { get; set; }

        public virtual SEXO SEXO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ROTA> ROTA { get; set; }
    }
}
