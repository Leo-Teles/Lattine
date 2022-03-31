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
        /// Busca um GrupoInfraestrutura através de seu id
        /// </summary>
        /// <param name="id">id do GrupoInfraestrutura buscado</param>
        /// <returns>O GrupoInfraestrutura buscado</returns>
        GrupoInfraestrutura Listarid(int id);

        /// <summary>
        /// Cadastra um novo GrupoInfraestrutura
        /// </summary>
        /// <param name="novoGrupoInfraestrutura">Objeto novoGrupoInfraestrutura com os novos dados</param>
        void Cadastrar(GrupoInfraestrutura novoGrupoInfraestrutura);

        /// <summary>
        /// Atualiza um GrupoInfraestrutura existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="idGrupoInfraestrutura">id do GrupoInfraestrutura que será atualizado</param>
        /// <param name="GrupoInfraestruturaAtualizado">Objeto GrupoInfraestruturaAtualizado com os novos dados</param>
        void Atualizar(int idGrupoInfraestrutura, GrupoInfraestrutura GrupoInfraestruturaAtualizado);

        /// <summary>
        /// Deleta um GrupoInfraestrutura existente
        /// </summary>
        /// <param name="idGrupoInfraestrutura">id do GrupoInfraestrutura deletado</param>
        void Deletar(int idGrupoInfraestrutura);
    }
}
