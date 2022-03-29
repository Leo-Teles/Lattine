using System;
using System.Collections.Generic;

#nullable disable

namespace Projeto_Lattine_Group.Domains
{
    public partial class GrupoRecurso
    {
        public short IdGrupoRecursos { get; set; }
        public short? IdUsuario { get; set; }
        public string NomeGrupoRecursos { get; set; }
        public DateTime? DataCadastro { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
