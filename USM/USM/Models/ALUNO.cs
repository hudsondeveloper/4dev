namespace USM.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ALUNO")]
    public partial class ALUNO
    {
        [Key]
        public int ID_ALUNO { get; set; }

        [Required]
        [StringLength(100)]
        public string NOME_ALUNO { get; set; }

        [Required]
        [StringLength(15)]
        public string CPF_ALUNO { get; set; }

        [Required]
        [StringLength(15)]
        public string TITULO_ELEITOR { get; set; }

        [Required]
        [StringLength(200)]
        public string ENDERECO_ALUNO { get; set; }

        [Required]
        [StringLength(30)]
        public string TELEFONE_ALUNO { get; set; }

        [Required]
        [StringLength(30)]
        public string RUA { get; set; }

        public int NUMERO { get; set; }

        [StringLength(30)]
        public string COMPLEMENTO { get; set; }

        [Required]
        [StringLength(1)]
        public string BAIRRO { get; set; }

        [Required]
        [StringLength(1)]
        public string CEP { get; set; }

        public int ID_FACULDADE { get; set; }

        public int ID_ROTA { get; set; }

        public int ID_TURNO_FACULDADE { get; set; }

        public virtual FACULDADE FACULDADE { get; set; }

        public virtual ROTA ROTA { get; set; }

        public virtual TURNO TURNO { get; set; }
    }
}
