using System;
using System.Collections.Generic;

#nullable disable

namespace Projeto_Lattine_Group.Domains
{
    public partial class EnderecoIp
    {
        public EnderecoIp()
        {
            RedeVirtuals = new HashSet<RedeVirtual>();
        }

        public short IdEnderecoIp { get; set; }
        public string Endereco { get; set; }

        public virtual ICollection<RedeVirtual> RedeVirtuals { get; set; }
    }
}
