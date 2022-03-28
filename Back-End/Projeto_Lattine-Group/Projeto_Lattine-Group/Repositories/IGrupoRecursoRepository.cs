using Projeto_Lattine_Group.Domains;
using System.Collections.Generic;

namespace Projeto_Lattine_Group.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório GrupoRecursoRepository
    /// </summary>
    interface IGrupoRecursoRepository
    {
        /// <summary>
        /// Lista todos os GrupoRecursos
        /// </summary>
        /// <returns>Lista de GrupoRecursos</returns>
        List<GrupoRecurso> Listar();

        /// <summary>
        /// Busca um GrupoRecurso através de seu id
        /// </summary>
        /// <param name="id">id do GrupoRecurso buscado</param>
        /// <returns>O GrupoRecurso buscado</returns>
        GrupoRecurso Listarid(int id);

        /// <summary>
        /// Cadastra um novo GrupoRecurso
        /// </summary>
        /// <param name="novoGrupoRecurso">Objeto novoGrupoRecurso com os novos dados</param>
        void Cadastrar(GrupoRecurso novoGrupoRecurso);

        /// <summary>
        /// Atualiza um GrupoRecurso existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="idGrupoRecurso">id do GrupoRecurso que será atualizado</param>
        /// <param name="GrupoRecursoAtualizado">Objeto GrupoRecursoAtualizado com os novos dados</param>
        void Atualizar(int idGrupoRecurso, GrupoRecurso GrupoRecursoAtualizado);

        /// <summary>
        /// Deleta um GrupoRecurso existente
        /// </summary>
        /// <param name="idGrupoRecurso">id do GrupoRecurso deletado</param>
        void Deletar(int idGrupoRecurso);
    }
}
