using System;
using System.Collections.Generic;

#nullable disable

namespace Projeto_Lattine_Group.Domains
{
    public partial class Infraestrutura
    {
        public Infraestrutura()
        {
            MaquinaVirtuals = new HashSet<MaquinaVirtual>();
            RedeVirtuals = new HashSet<RedeVirtual>();
            ServicoAplicacionals = new HashSet<ServicoAplicacional>();
        }

        public short IdInfraestrutura { get; set; }
        public short? IdUsuario { get; set; }
        public DateTime? DataCadastro { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<MaquinaVirtual> MaquinaVirtuals { get; set; }
        public virtual ICollection<RedeVirtual> RedeVirtuals { get; set; }
        public virtual ICollection<ServicoAplicacional> ServicoAplicacionals { get; set; }
    }
}
