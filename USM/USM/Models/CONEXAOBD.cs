namespace USM.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CONEXAOBD : DbContext
    {
        public CONEXAOBD()
            : base("name=CONEXAOBD")
        {
        }

        public virtual DbSet<ALUNO> ALUNO { get; set; }
        public virtual DbSet<ESTADO_CIVIL> ESTADO_CIVIL { get; set; }
        public virtual DbSet<FACULDADE> FACULDADE { get; set; }
        public virtual DbSet<MOTORISTA> MOTORISTA { get; set; }
        public virtual DbSet<ONIBUS> ONIBUS { get; set; }
        public virtual DbSet<PONTOS_PARADA_CAMACARI> PONTOS_PARADA_CAMACARI { get; set; }
        public virtual DbSet<PONTOS_PARADA_SALVADOR> PONTOS_PARADA_SALVADOR { get; set; }
        public virtual DbSet<ROTA> ROTA { get; set; }
        public virtual DbSet<SEXO> SEXO { get; set; }
        public virtual DbSet<TURNO> TURNO { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ALUNO>()
                .Property(e => e.NOME_ALUNO)
                .IsUnicode(false);

            modelBuilder.Entity<ALUNO>()
                .Property(e => e.CPF_ALUNO)
                .IsUnicode(false);

            modelBuilder.Entity<ALUNO>()
                .Property(e => e.TITULO_ELEITOR)
                .IsUnicode(false);

            modelBuilder.Entity<ALUNO>()
                .Property(e => e.ENDERECO_ALUNO)
                .IsUnicode(false);

            modelBuilder.Entity<ALUNO>()
                .Property(e => e.TELEFONE_ALUNO)
                .IsUnicode(false);

            modelBuilder.Entity<ALUNO>()
                .Property(e => e.RUA)
                .IsUnicode(false);

            modelBuilder.Entity<ALUNO>()
                .Property(e => e.COMPLEMENTO)
                .IsUnicode(false);

            modelBuilder.Entity<ALUNO>()
                .Property(e => e.BAIRRO)
                .IsUnicode(false);

            modelBuilder.Entity<ALUNO>()
                .Property(e => e.CEP)
                .IsUnicode(false);

            modelBuilder.Entity<ESTADO_CIVIL>()
                .Property(e => e.DESCRICAO)
                .IsUnicode(false);

            modelBuilder.Entity<ESTADO_CIVIL>()
                .HasMany(e => e.MOTORISTA)
                .WithRequired(e => e.ESTADO_CIVIL)
                .HasForeignKey(e => e.ESTADO_CIVIL_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FACULDADE>()
                .Property(e => e.NOME_FACULDADE)
                .IsUnicode(false);

            modelBuilder.Entity<FACULDADE>()
                .HasMany(e => e.ALUNO)
                .WithRequired(e => e.FACULDADE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MOTORISTA>()
                .Property(e => e.NOME_MOTORISTA)
                .IsUnicode(false);

            modelBuilder.Entity<MOTORISTA>()
                .Property(e => e.ENDERECO_MOTORISTA)
                .IsUnicode(false);

            modelBuilder.Entity<MOTORISTA>()
                .Property(e => e.TELEFONE_MOTORISTA)
                .IsUnicode(false);

            modelBuilder.Entity<MOTORISTA>()
                .HasMany(e => e.ROTA)
                .WithRequired(e => e.MOTORISTA)
                .HasForeignKey(e => e.MATRICULA_MOTORISTA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ONIBUS>()
                .Property(e => e.PLACA)
                .IsUnicode(false);

            modelBuilder.Entity<ONIBUS>()
                .Property(e => e.EMPRESA)
                .IsUnicode(false);

            modelBuilder.Entity<ONIBUS>()
                .HasMany(e => e.ROTA)
                .WithRequired(e => e.ONIBUS)
                .HasForeignKey(e => e.PLACA_ONIBUS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PONTOS_PARADA_CAMACARI>()
                .Property(e => e.NOME_PONTO_PARADA_CAMACARI)
                .IsUnicode(false);

            modelBuilder.Entity<PONTOS_PARADA_SALVADOR>()
                .Property(e => e.NOME_PONTO_PARADA_SALVADOR)
                .IsUnicode(false);

            modelBuilder.Entity<ROTA>()
                .Property(e => e.NOME_ROTA)
                .IsUnicode(false);

            modelBuilder.Entity<ROTA>()
                .Property(e => e.PLACA_ONIBUS)
                .IsUnicode(false);

            modelBuilder.Entity<ROTA>()
                .HasMany(e => e.ALUNO)
                .WithRequired(e => e.ROTA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ROTA>()
                .HasMany(e => e.PONTOS_PARADA_CAMACARI)
                .WithMany(e => e.ROTA)
                .Map(m => m.ToTable("ROTA_PONTOS_CAMACARI").MapLeftKey("ID_ROTA").MapRightKey("ID_PONTO_PARADA_CAMACARI"));

            modelBuilder.Entity<ROTA>()
                .HasMany(e => e.PONTOS_PARADA_SALVADOR)
                .WithMany(e => e.ROTA)
                .Map(m => m.ToTable("ROTA_PONTOS_SALVADOR").MapLeftKey("ID_ROTA").MapRightKey("ID_PONTO_PARADA_SALVADOR"));

            modelBuilder.Entity<SEXO>()
                .Property(e => e.DESCRICAO)
                .IsUnicode(false);

            modelBuilder.Entity<SEXO>()
                .HasMany(e => e.MOTORISTA)
                .WithRequired(e => e.SEXO)
                .HasForeignKey(e => e.SEXO_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TURNO>()
                .Property(e => e.DESCRICAO)
                .IsUnicode(false);

            modelBuilder.Entity<TURNO>()
                .HasMany(e => e.ALUNO)
                .WithRequired(e => e.TURNO)
                .HasForeignKey(e => e.ID_TURNO_FACULDADE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TURNO>()
                .HasMany(e => e.ROTA)
                .WithRequired(e => e.TURNO)
                .HasForeignKey(e => e.ID_TURNO_ROTA)
                .WillCascadeOnDelete(false);
        }
    }
}
