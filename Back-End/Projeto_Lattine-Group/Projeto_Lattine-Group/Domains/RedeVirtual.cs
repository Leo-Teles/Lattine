using System;
using System.Collections.Generic;

#nullable disable

namespace Projeto_Lattine_Group.Domains
{
    public partial class RedeVirtual
    {
        public short IdRedeVirtual { get; set; }
        public short? IdInfraestrutura { get; set; }
        public short? IdEnderecoIp { get; set; }
        public short? IdSubRede { get; set; }
        public string NomeRedeVirtual { get; set; }
        public bool BastionHost { get; set; }
        public bool ProtecaoDdoS { get; set; }
        public bool FireWall { get; set; }

        public virtual EnderecoIp IdEnderecoIpNavigation { get; set; }
        public virtual Infraestrutura IdInfraestruturaNavigation { get; set; }
        public virtual SubRede IdSubRedeNavigation { get; set; }
    }
}
