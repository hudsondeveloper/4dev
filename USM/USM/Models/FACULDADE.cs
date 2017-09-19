namespace USM.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FACULDADE")]
    public partial class FACULDADE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FACULDADE()
        {
            ALUNO = new HashSet<ALUNO>();
        }

        [Key]
        public int ID_FACULDADE { get; set; }

        [Required]
        [StringLength(50)]
        public string NOME_FACULDADE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ALUNO> ALUNO { get; set; }
    }
}
