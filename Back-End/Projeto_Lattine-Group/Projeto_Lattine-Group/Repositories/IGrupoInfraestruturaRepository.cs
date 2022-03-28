using Projeto_Lattine_Group.Domains;
using System.Collections.Generic;

namespace Projeto_Lattine_Group.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório GrupoInfraestruturaRepository
    /// </summary>
    interface IGrupoInfraestruturaRepository
    {
        /// <summary>
        /// Lista todos os GrupoInfraestruturas
        /// </summary>
        /// <returns>Lista de GrupoInfraestruturas</returns>
        List<GrupoInfraestrutura> Listar();

        /// <summary>
        /// Cadastra um novo GrupoInfraestrutura
        /// </summary>
        /// <param name="novoGrupoInfraestrutura">Objeto novoGrupoInfraestrutura com os novos dados</param>
        void Cadastrar(GrupoInfraestrutura novoGrupoInfraestrutura);
    }
}
