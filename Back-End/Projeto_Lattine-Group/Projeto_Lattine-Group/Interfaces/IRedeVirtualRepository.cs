using Projeto_Lattine_Group.Domains;
using System.Collections.Generic;

namespace Projeto_Lattine_Group.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório RedeVirtualRepository
    /// </summary>
    interface IRedeVirtualRepository
    {
        /// <summary>
        /// Lista todas as RedeVirtuals
        /// </summary>
        /// <returns>Lista de RedeVirtuals</returns>
        List<RedeVirtual> Listar();

        /// <summary>
        /// Busca uma RedeVirtual através de seu id
        /// </summary>
        /// <param name="id">id da RedeVirtual buscada</param>
        /// <returns>A RedeVirtual buscada</returns>
        RedeVirtual Listarid(int id);

        /// <summary>
        /// Cadastra uma nova RedeVirtual
        /// </summary>
        /// <param name="novaRedeVirtual">Objeto novaRedeVirtual com os novos dados</param>
        void Cadastrar(RedeVirtual novaRedeVirtual);

        /// <summary>
        /// Atualiza uma RedeVirtual existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="idRedeVirtual">id da RedeVirtual que será atualizada</param>
        /// <param name="RedeVirtualAtualizada">Objeto RedeVirtualAtualizada com os novos dados</param>
        void Atualizar(int idRedeVirtual, RedeVirtual RedeVirtualAtualizada);

        /// <summary>
        /// Deleta uma RedeVirtual existente
        /// </summary>
        /// <param name="idRedeVirtual">id da RedeVirtual deletada</param>
        void Deletar(int idRedeVirtual);

        /// <summary>
        /// Lista todas as redes virtuais do usuário logado
        /// </summary>
        /// <param name="id">ID do usuário logado</param>
        /// <returns>Uma lista de redes virtuais do usuário</returns>
        List<RedeVirtual> ListarMinhas(int id);

        /// <summary>
        /// Lista uma rede virtual
        /// </summary>
        /// <param name="id">ID da rede virtual</param>
        /// <returns>Uma rede virtual</returns>
        List<RedeVirtual> ListarUma(int id);
    }
}
