using System;
using System.Collections.Generic;

#nullable disable

namespace Projeto_Lattine_Group.Domains
{
    public partial class ServicoAplicacional
    {
        public short IdServicoAplicacional { get; set; }
        public string NomeServicoAplicacional { get; set; }
        public string PilhaRuntime { get; set; }
        public string SkueTamanho { get; set; }
        public short? IdUsuario { get; set; }
        public DateTime? DataCadastro { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
