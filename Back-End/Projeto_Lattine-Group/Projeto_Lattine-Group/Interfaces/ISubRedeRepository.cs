using Projeto_Lattine_Group.Domains;
using System.Collections.Generic;

namespace Projeto_Lattine_Group.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório SubRedeRepository
    /// </summary>
    interface ISubRedeRepository
    {
        /// <summary>
        /// Lista todas as SubRedes
        /// </summary>
        /// <returns>Lista de SubRedes</returns>
        List<SubRede> Listar();

        /// <summary>
        /// Busca uma SubRede através de seu id
        /// </summary>
        /// <param name="id">id da SubRede buscada</param>
        /// <returns>A SubRede buscada</returns>
        SubRede Listarid(int id);

        /// <summary>
        /// Cadastra uma nova SubRede
        /// </summary>
        /// <param name="novaSubRede">Objeto novaSubRede com os novos dados</param>
        void Cadastrar(SubRede novaSubRede);

        /// <summary>
        /// Atualiza uma SubRede existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="idSubRede">id da SubRede que será atualizada</param>
        /// <param name="SubRedeAtualizada">Objeto SubRedeAtualizada com os novos dados</param>
        void Atualizar(int idSubRede, SubRede SubRedeAtualizada);

        /// <summary>
        /// Deleta uma SubRede existente
        /// </summary>
        /// <param name="idSubRede">id da SubRede deletada</param>
        void Deletar(int idSubRede);

        /// <summary>
        /// Lista todas as sub-redes do usuário logado
        /// </summary>
        /// <param name="id">ID do usuário logado</param>
        /// <returns>Uma lista de sub-redes do usuário</returns>
        List<SubRede> ListarMinhas(int id);
    }
}
