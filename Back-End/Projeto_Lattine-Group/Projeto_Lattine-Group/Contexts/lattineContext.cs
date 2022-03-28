using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Projeto_Lattine_Group.Domains;

#nullable disable

namespace Projeto_Lattine_Group.Contexts
{
    public partial class lattineContext : DbContext
    {
        public lattineContext()
        {
        }

        public lattineContext(DbContextOptions<lattineContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ContatosLattine> ContatosLattines { get; set; }
        public virtual DbSet<EnderecoIp> EnderecoIps { get; set; }
        public virtual DbSet<GrupoInfraestrutura> GrupoInfraestruturas { get; set; }
        public virtual DbSet<GrupoRecurso> GrupoRecursos { get; set; }
        public virtual DbSet<Infraestrutura> Infraestruturas { get; set; }
        public virtual DbSet<MaquinaVirtual> MaquinaVirtuals { get; set; }
        public virtual DbSet<RedeVirtual> RedeVirtuals { get; set; }
        public virtual DbSet<ServicoAplicacional> ServicoAplicacionals { get; set; }
        public virtual DbSet<SubRede> SubRedes { get; set; }
        public virtual DbSet<Telefone> Telefones { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=NOTE0113B3\\SQLEXPRESS; initial catalog=lattine; user Id=sa; pwd=Senai@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<ContatosLattine>(entity =>
            {
                entity.HasKey(e => e.IdContatosLattine)
                    .HasName("PK__contatos__4E9166FA6409C19C");

                entity.ToTable("contatosLattine");

                entity.HasIndex(e => e.Localizacao, "UQ__contatos__601F3596497688AF")
                    .IsUnique();

                entity.Property(e => e.IdContatosLattine).HasColumnName("idContatosLattine");

                entity.Property(e => e.Localizacao)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("localizacao");
            });

            modelBuilder.Entity<EnderecoIp>(entity =>
            {
                entity.HasKey(e => e.IdEnderecoIp)
                    .HasName("PK__endereco__C4CF02F8956B7CBA");

                entity.ToTable("enderecoIP");

                entity.Property(e => e.IdEnderecoIp).HasColumnName("idEnderecoIP");

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("endereco");
            });

            modelBuilder.Entity<GrupoInfraestrutura>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("grupoInfraestrutura");

                entity.Property(e => e.IdGrupoRecursos).HasColumnName("idGrupoRecursos");

                entity.Property(e => e.IdInfraestrutura).HasColumnName("idInfraestrutura");

                entity.HasOne(d => d.IdGrupoRecursosNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdGrupoRecursos)
                    .HasConstraintName("FK__grupoInfr__idGru__36B12243");

                entity.HasOne(d => d.IdInfraestruturaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdInfraestrutura)
                    .HasConstraintName("FK__grupoInfr__idInf__37A5467C");
            });

            modelBuilder.Entity<GrupoRecurso>(entity =>
            {
                entity.HasKey(e => e.IdGrupoRecursos)
                    .HasName("PK__grupoRec__4E52ECCB74A2DB4C");

                entity.ToTable("grupoRecursos");

                entity.HasIndex(e => e.NomeGrupoRecursos, "UQ__grupoRec__BC3B784971BCB11A")
                    .IsUnique();

                entity.Property(e => e.IdGrupoRecursos).HasColumnName("idGrupoRecursos");

                entity.Property(e => e.DataCadastro)
                    .HasColumnType("datetime")
                    .HasColumnName("dataCadastro");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.NomeGrupoRecursos)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("nomeGrupoRecursos");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.GrupoRecursos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__grupoRecu__idUsu__32E0915F");
            });

            modelBuilder.Entity<Infraestrutura>(entity =>
            {
                entity.HasKey(e => e.IdInfraestrutura)
                    .HasName("PK__infraest__973745E9BF7484EC");

                entity.ToTable("infraestrutura");

                entity.Property(e => e.IdInfraestrutura).HasColumnName("idInfraestrutura");

                entity.Property(e => e.DataCadastro)
                    .HasColumnType("datetime")
                    .HasColumnName("dataCadastro");
            });

            modelBuilder.Entity<MaquinaVirtual>(entity =>
            {
                entity.HasKey(e => e.IdMaquinaVirtual)
                    .HasName("PK__maquinaV__3F823F3357F3F73D");

                entity.ToTable("maquinaVirtual");

                entity.HasIndex(e => e.NomeMaquinaVirtual, "UQ__maquinaV__3F71306A85883E24")
                    .IsUnique();

                entity.HasIndex(e => e.NomeAdmin, "UQ__maquinaV__B0F01B07B71B3E14")
                    .IsUnique();

                entity.Property(e => e.IdMaquinaVirtual).HasColumnName("idMaquinaVirtual");

                entity.Property(e => e.IdInfraestrutura).HasColumnName("idInfraestrutura");

                entity.Property(e => e.NomeAdmin)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("nomeAdmin");

                entity.Property(e => e.NomeMaquinaVirtual)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("nomeMaquinaVirtual");

                entity.Property(e => e.OpcoesDisponibilidade)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("opcoesDisponibilidade");

                entity.Property(e => e.OrigemChavePublicaSsh)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("origemChavePublicaSSH");

                entity.Property(e => e.SistemaOperacional)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("sistemaOperacional");

                entity.Property(e => e.Tamanho)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tamanho");

                entity.HasOne(d => d.IdInfraestruturaNavigation)
                    .WithMany(p => p.MaquinaVirtuals)
                    .HasForeignKey(d => d.IdInfraestrutura)
                    .HasConstraintName("FK__maquinaVi__idInf__3C69FB99");
            });

            modelBuilder.Entity<RedeVirtual>(entity =>
            {
                entity.HasKey(e => e.IdRedeVirtual)
                    .HasName("PK__redeVirt__B3038BF667E3C692");

                entity.ToTable("redeVirtual");

                entity.HasIndex(e => e.NomeRedeVirtual, "UQ__redeVirt__03572315E813ACD9")
                    .IsUnique();

                entity.Property(e => e.IdRedeVirtual).HasColumnName("idRedeVirtual");

                entity.Property(e => e.BastionHost).HasColumnName("bastionHost");

                entity.Property(e => e.FireWall).HasColumnName("fireWall");

                entity.Property(e => e.IdEnderecoIp).HasColumnName("idEnderecoIP");

                entity.Property(e => e.IdInfraestrutura).HasColumnName("idInfraestrutura");

                entity.Property(e => e.IdSubRede).HasColumnName("idSubRede");

                entity.Property(e => e.NomeRedeVirtual)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("nomeRedeVirtual");

                entity.Property(e => e.ProtecaoDdoS).HasColumnName("protecaoDDoS");

                entity.HasOne(d => d.IdEnderecoIpNavigation)
                    .WithMany(p => p.RedeVirtuals)
                    .HasForeignKey(d => d.IdEnderecoIp)
                    .HasConstraintName("FK__redeVirtu__idEnd__45F365D3");

                entity.HasOne(d => d.IdInfraestruturaNavigation)
                    .WithMany(p => p.RedeVirtuals)
                    .HasForeignKey(d => d.IdInfraestrutura)
                    .HasConstraintName("FK__redeVirtu__idInf__44FF419A");

                entity.HasOne(d => d.IdSubRedeNavigation)
                    .WithMany(p => p.RedeVirtuals)
                    .HasForeignKey(d => d.IdSubRede)
                    .HasConstraintName("FK__redeVirtu__idSub__46E78A0C");
            });

            modelBuilder.Entity<ServicoAplicacional>(entity =>
            {
                entity.HasKey(e => e.IdServicoAplicacional)
                    .HasName("PK__servicoA__632AB756A08893D0");

                entity.ToTable("servicoAplicacional");

                entity.HasIndex(e => e.NomeServicoAplicacional, "UQ__servicoA__C836D3AADCE01084")
                    .IsUnique();

                entity.Property(e => e.IdServicoAplicacional).HasColumnName("idServicoAplicacional");

                entity.Property(e => e.IdInfraestrutura).HasColumnName("idInfraestrutura");

                entity.Property(e => e.NomeServicoAplicacional)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("nomeServicoAplicacional");

                entity.Property(e => e.PilhaRuntime)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("pilhaRuntime");

                entity.Property(e => e.SkueTamanho)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SKUeTamanho");

                entity.HasOne(d => d.IdInfraestruturaNavigation)
                    .WithMany(p => p.ServicoAplicacionals)
                    .HasForeignKey(d => d.IdInfraestrutura)
                    .HasConstraintName("FK__servicoAp__idInf__4AB81AF0");
            });

            modelBuilder.Entity<SubRede>(entity =>
            {
                entity.HasKey(e => e.IdSubRede)
                    .HasName("PK__subRede__12D6C82E4459388F");

                entity.ToTable("subRede");

                entity.HasIndex(e => e.NomeSubRede, "UQ__subRede__60FA1F7BC9130461")
                    .IsUnique();

                entity.Property(e => e.IdSubRede).HasColumnName("idSubRede");

                entity.Property(e => e.IntervalosEndereco)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("intervalosEndereco");

                entity.Property(e => e.NomeSubRede)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("nomeSubRede");
            });

            modelBuilder.Entity<Telefone>(entity =>
            {
                entity.HasKey(e => e.IdTelefone)
                    .HasName("PK__telefone__39C142D5F4B6CE40");

                entity.ToTable("telefone");

                entity.Property(e => e.IdTelefone).HasColumnName("idTelefone");

                entity.Property(e => e.IdContatosLattine).HasColumnName("idContatosLattine");

                entity.Property(e => e.Numero)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("numero");

                entity.HasOne(d => d.IdContatosLattineNavigation)
                    .WithMany(p => p.Telefones)
                    .HasForeignKey(d => d.IdContatosLattine)
                    .HasConstraintName("FK__telefone__idCont__276EDEB3");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__tipoUsua__03006BFF37107F80");

                entity.ToTable("tipoUsuario");

                entity.HasIndex(e => e.Titulo, "UQ__tipoUsua__38FA640FCB9A2A4E")
                    .IsUnique();

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("titulo");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__usuario__645723A6125A6F50");

                entity.ToTable("usuario");

                entity.HasIndex(e => e.Email, "UQ__usuario__AB6E6164658555FD")
                    .IsUnique();

                entity.HasIndex(e => e.Senha, "UQ__usuario__D8D98E82138A8769")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.DataCadastro)
                    .HasColumnType("datetime")
                    .HasColumnName("dataCadastro");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.Property(e => e.Sobrenome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("sobrenome");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__usuario__idTipoU__2F10007B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
