using System;
using System.Collections.Generic;

#nullable disable

namespace Projeto_Lattine_Group.Domains
{
    public partial class ContatosLattine
    {
        public ContatosLattine()
        {
            Telefones = new HashSet<Telefone>();
        }

        public short IdContatosLattine { get; set; }
        public string Localizacao { get; set; }

        public virtual ICollection<Telefone> Telefones { get; set; }
    }
}
