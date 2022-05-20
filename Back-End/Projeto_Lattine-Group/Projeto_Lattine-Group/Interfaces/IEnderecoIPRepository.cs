using Projeto_Lattine_Group.Domains;
using System.Collections.Generic;

namespace Projeto_Lattine_Group.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório EnderecoIPRepository
    /// </summary>
    interface IEnderecoIPRepository
    {
        /// <summary>
        /// Lista todos os EnderecoIPs
        /// </summary>
        /// <returns>Lista de EnderecoIPs</returns>
        List<EnderecoIp> Listar();

        /// <summary>
        /// Busca um EnderecoIP através de seu id
        /// </summary>
        /// <param name="id">id do EnderecoIP buscado</param>
        /// <returns>O EnderecoIP buscado</returns>
        EnderecoIp Listarid(int id);

        /// <summary>
        /// Cadastra um novo EnderecoIP
        /// </summary>
        /// <param name="novoEnderecoIP">Objeto novoEnderecoIP com os novos dados</param>
        void Cadastrar(EnderecoIp novoEnderecoIP);

        /// <summary>
        /// Atualiza um EnderecoIP existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="idEnderecoIP">id do EnderecoIP que será atualizado</param>
        /// <param name="EnderecoIPAtualizado">Objeto EnderecoIPAtualizado com os novos dados</param>
        void Atualizar(int idEnderecoIP, EnderecoIp EnderecoIPAtualizado);

        /// <summary>
        /// Deleta um EnderecoIP existente
        /// </summary>
        /// <param name="idEnderecoIP">id do EnderecoIP deletado</param>
        void Deletar(int idEnderecoIP);

        /// <summary>
        /// Lista todos os ips do usuário logado
        /// </summary>
        /// <param name="id">ID do usuário logado</param>
        /// <returns>Uma lista de ips do usuário</returns>
        List<EnderecoIp> ListarMeus(int id);
    }
}
