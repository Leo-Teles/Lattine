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
                    .HasName("PK__contatos__4E9166FACE49AF27");

                entity.ToTable("contatosLattine");

                entity.HasIndex(e => e.Localizacao, "UQ__contatos__601F3596BC3664FB")
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
                    .HasName("PK__endereco__C4CF02F8B88A5DE1");

                entity.ToTable("enderecoIP");

                entity.Property(e => e.IdEnderecoIp).HasColumnName("idEnderecoIP");

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("endereco");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.EnderecoIps)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__enderecoI__idUsu__36B12243");
            });

            modelBuilder.Entity<MaquinaVirtual>(entity =>
            {
                entity.HasKey(e => e.IdMaquinaVirtual)
                    .HasName("PK__maquinaV__3F823F3390109B3F");

                entity.ToTable("maquinaVirtual");

                entity.HasIndex(e => e.NomeMaquinaVirtual, "UQ__maquinaV__3F71306AF38C0FFD")
                    .IsUnique();

                entity.HasIndex(e => e.NomeAdmin, "UQ__maquinaV__B0F01B072A989BF3")
                    .IsUnique();

                entity.Property(e => e.IdMaquinaVirtual).HasColumnName("idMaquinaVirtual");

                entity.Property(e => e.DataCadastro)
                    .HasColumnType("datetime")
                    .HasColumnName("dataCadastro");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

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

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.MaquinaVirtuals)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__maquinaVi__idUsu__33D4B598");
            });

            modelBuilder.Entity<RedeVirtual>(entity =>
            {
                entity.HasKey(e => e.IdRedeVirtual)
                    .HasName("PK__redeVirt__B3038BF6F7D938AA");

                entity.ToTable("redeVirtual");

                entity.HasIndex(e => e.NomeRedeVirtual, "UQ__redeVirt__0357231544E517A9")
                    .IsUnique();

                entity.Property(e => e.IdRedeVirtual).HasColumnName("idRedeVirtual");

                entity.Property(e => e.BastionHost).HasColumnName("bastionHost");

                entity.Property(e => e.DataCadastro)
                    .HasColumnType("datetime")
                    .HasColumnName("dataCadastro");

                entity.Property(e => e.FireWall).HasColumnName("fireWall");

                entity.Property(e => e.IdEnderecoIp).HasColumnName("idEnderecoIP");

                entity.Property(e => e.IdSubRede).HasColumnName("idSubRede");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.NomeRedeVirtual)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("nomeRedeVirtual");

                entity.Property(e => e.ProtecaoDdoS).HasColumnName("protecaoDDoS");

                entity.HasOne(d => d.IdEnderecoIpNavigation)
                    .WithMany(p => p.RedeVirtuals)
                    .HasForeignKey(d => d.IdEnderecoIp)
                    .HasConstraintName("FK__redeVirtu__idEnd__3E52440B");

                entity.HasOne(d => d.IdSubRedeNavigation)
                    .WithMany(p => p.RedeVirtuals)
                    .HasForeignKey(d => d.IdSubRede)
                    .HasConstraintName("FK__redeVirtu__idSub__3F466844");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.RedeVirtuals)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__redeVirtu__idUsu__403A8C7D");
            });

            modelBuilder.Entity<ServicoAplicacional>(entity =>
            {
                entity.HasKey(e => e.IdServicoAplicacional)
                    .HasName("PK__servicoA__632AB7566A650C73");

                entity.ToTable("servicoAplicacional");

                entity.HasIndex(e => e.NomeServicoAplicacional, "UQ__servicoA__C836D3AAAE72D29D")
                    .IsUnique();

                entity.Property(e => e.IdServicoAplicacional).HasColumnName("idServicoAplicacional");

                entity.Property(e => e.DataCadastro)
                    .HasColumnType("datetime")
                    .HasColumnName("dataCadastro");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

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

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.ServicoAplicacionals)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__servicoAp__idUsu__440B1D61");
            });

            modelBuilder.Entity<SubRede>(entity =>
            {
                entity.HasKey(e => e.IdSubRede)
                    .HasName("PK__subRede__12D6C82EE393D859");

                entity.ToTable("subRede");

                entity.HasIndex(e => e.NomeSubRede, "UQ__subRede__60FA1F7B6C2AAE63")
                    .IsUnique();

                entity.Property(e => e.IdSubRede).HasColumnName("idSubRede");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

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

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.SubRedes)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__subRede__idUsuar__3A81B327");
            });

            modelBuilder.Entity<Telefone>(entity =>
            {
                entity.HasKey(e => e.IdTelefone)
                    .HasName("PK__telefone__39C142D5B064CD17");

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
                    .HasName("PK__tipoUsua__03006BFF1ECE2211");

                entity.ToTable("tipoUsuario");

                entity.HasIndex(e => e.Titulo, "UQ__tipoUsua__38FA640F8C28BB89")
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
                    .HasName("PK__usuario__645723A6A26376A7");

                entity.ToTable("usuario");

                entity.HasIndex(e => e.Email, "UQ__usuario__AB6E61647D736C0D")
                    .IsUnique();

                entity.HasIndex(e => e.Senha, "UQ__usuario__D8D98E82964019FB")
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
