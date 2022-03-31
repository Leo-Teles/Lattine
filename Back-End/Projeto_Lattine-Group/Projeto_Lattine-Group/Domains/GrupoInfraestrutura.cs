using System;
using System.Collections.Generic;

#nullable disable

namespace Projeto_Lattine_Group.Domains
{
    public partial class GrupoInfraestrutura
    {
        public short IdGrupoInfraestrutura { get; set; }
        public short? IdGrupoRecursos { get; set; }
        public short? IdInfraestrutura { get; set; }

        public virtual GrupoRecurso IdGrupoRecursosNavigation { get; set; }
        public virtual Infraestrutura IdInfraestruturaNavigation { get; set; }
    }
}
