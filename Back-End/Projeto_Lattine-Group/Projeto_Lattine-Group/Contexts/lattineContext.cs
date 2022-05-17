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
                    .HasName("PK__contatos__4E9166FAC39EAB03");

                entity.ToTable("contatosLattine");

                entity.HasIndex(e => e.Localizacao, "UQ__contatos__601F35967DA98504")
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
                    .HasName("PK__endereco__C4CF02F8BC614068");

                entity.ToTable("enderecoIP");

                entity.Property(e => e.IdEnderecoIp).HasColumnName("idEnderecoIP");

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("endereco");
            });

            modelBuilder.Entity<Infraestrutura>(entity =>
            {
                entity.HasKey(e => e.IdInfraestrutura)
                    .HasName("PK__infraest__973745E96DB3FFD3");

                entity.ToTable("infraestrutura");

                entity.Property(e => e.IdInfraestrutura).HasColumnName("idInfraestrutura");

                entity.Property(e => e.DataCadastro)
                    .HasColumnType("datetime")
                    .HasColumnName("dataCadastro");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Infraestruturas)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__infraestr__idUsu__31EC6D26");
            });

            modelBuilder.Entity<MaquinaVirtual>(entity =>
            {
                entity.HasKey(e => e.IdMaquinaVirtual)
                    .HasName("PK__maquinaV__3F823F338FE8D76D");

                entity.ToTable("maquinaVirtual");

                entity.HasIndex(e => e.NomeMaquinaVirtual, "UQ__maquinaV__3F71306A1AB8292C")
                    .IsUnique();

                entity.HasIndex(e => e.NomeAdmin, "UQ__maquinaV__B0F01B079154655D")
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
                    .HasConstraintName("FK__maquinaVi__idInf__36B12243");
            });

            modelBuilder.Entity<RedeVirtual>(entity =>
            {
                entity.HasKey(e => e.IdRedeVirtual)
                    .HasName("PK__redeVirt__B3038BF6D3B87857");

                entity.ToTable("redeVirtual");

                entity.HasIndex(e => e.NomeRedeVirtual, "UQ__redeVirt__03572315A473F727")
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
                    .HasConstraintName("FK__redeVirtu__idEnd__403A8C7D");

                entity.HasOne(d => d.IdInfraestruturaNavigation)
                    .WithMany(p => p.RedeVirtuals)
                    .HasForeignKey(d => d.IdInfraestrutura)
                    .HasConstraintName("FK__redeVirtu__idInf__3F466844");

                entity.HasOne(d => d.IdSubRedeNavigation)
                    .WithMany(p => p.RedeVirtuals)
                    .HasForeignKey(d => d.IdSubRede)
                    .HasConstraintName("FK__redeVirtu__idSub__412EB0B6");
            });

            modelBuilder.Entity<ServicoAplicacional>(entity =>
            {
                entity.HasKey(e => e.IdServicoAplicacional)
                    .HasName("PK__servicoA__632AB756BBCBC708");

                entity.ToTable("servicoAplicacional");

                entity.HasIndex(e => e.NomeServicoAplicacional, "UQ__servicoA__C836D3AA25D2935F")
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
                    .HasConstraintName("FK__servicoAp__idInf__44FF419A");
            });

            modelBuilder.Entity<SubRede>(entity =>
            {
                entity.HasKey(e => e.IdSubRede)
                    .HasName("PK__subRede__12D6C82E76D54055");

                entity.ToTable("subRede");

                entity.HasIndex(e => e.NomeSubRede, "UQ__subRede__60FA1F7B00430C0D")
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
                    .HasName("PK__telefone__39C142D50FE3D687");

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
                    .HasName("PK__tipoUsua__03006BFF7DBB3EBD");

                entity.ToTable("tipoUsuario");

                entity.HasIndex(e => e.Titulo, "UQ__tipoUsua__38FA640F4E1A01B5")
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
                    .HasName("PK__usuario__645723A627108B6F");

                entity.ToTable("usuario");

                entity.HasIndex(e => e.Email, "UQ__usuario__AB6E616495038E78")
                    .IsUnique();

                entity.HasIndex(e => e.Senha, "UQ__usuario__D8D98E821A5A284E")
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
