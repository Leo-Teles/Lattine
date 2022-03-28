using System;
using System.Collections.Generic;

#nullable disable

namespace Projeto_Lattine_Group.Domains
{
    public partial class Telefone
    {
        public short IdTelefone { get; set; }
        public short? IdContatosLattine { get; set; }
        public string Numero { get; set; }

        public virtual ContatosLattine IdContatosLattineNavigation { get; set; }
    }
}
