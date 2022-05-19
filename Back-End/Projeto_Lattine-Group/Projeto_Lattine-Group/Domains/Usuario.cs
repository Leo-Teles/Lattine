using System;
using System.Collections.Generic;

#nullable disable

namespace Projeto_Lattine_Group.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            EnderecoIps = new HashSet<EnderecoIp>();
            MaquinaVirtuals = new HashSet<MaquinaVirtual>();
            RedeVirtuals = new HashSet<RedeVirtual>();
            ServicoAplicacionals = new HashSet<ServicoAplicacional>();
            SubRedes = new HashSet<SubRede>();
        }

        public short IdUsuario { get; set; }
        public short? IdTipoUsuario { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime? DataCadastro { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<EnderecoIp> EnderecoIps { get; set; }
        public virtual ICollection<MaquinaVirtual> MaquinaVirtuals { get; set; }
        public virtual ICollection<RedeVirtual> RedeVirtuals { get; set; }
        public virtual ICollection<ServicoAplicacional> ServicoAplicacionals { get; set; }
        public virtual ICollection<SubRede> SubRedes { get; set; }
    }
}
