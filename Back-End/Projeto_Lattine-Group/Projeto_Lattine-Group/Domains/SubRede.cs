using System;
using System.Collections.Generic;

#nullable disable

namespace Projeto_Lattine_Group.Domains
{
    public partial class SubRede
    {
        public SubRede()
        {
            RedeVirtuals = new HashSet<RedeVirtual>();
        }

        public short IdSubRede { get; set; }
        public short? IdUsuario { get; set; }
        public string NomeSubRede { get; set; }
        public string IntervalosEndereco { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<RedeVirtual> RedeVirtuals { get; set; }
    }
}
