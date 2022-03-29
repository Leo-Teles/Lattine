using System;
using System.Collections.Generic;

#nullable disable

namespace Projeto_Lattine_Group.Domains
{
    public partial class ServicoAplicacional
    {
        public short IdServicoAplicacional { get; set; }
        public short? IdInfraestrutura { get; set; }
        public string NomeServicoAplicacional { get; set; }
        public string PilhaRuntime { get; set; }
        public string SkueTamanho { get; set; }

        public virtual Infraestrutura IdInfraestruturaNavigation { get; set; }
    }
}
