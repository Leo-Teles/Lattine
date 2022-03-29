using Projeto_Lattine_Group.Domains;
using System.Collections.Generic;

namespace Projeto_Lattine_Group.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório ServicoAplicacionalRepository
    /// </summary>
    interface IServicoAplicacionalRepository
    {
        /// <summary>
        /// Lista todos os ServicoAplicacionals
        /// </summary>
        /// <returns>Lista de ServicoAplicacionals</returns>
        List<ServicoAplicacional> Listar();

        /// <summary>
        /// Busca um ServicoAplicacional através de seu id
        /// </summary>
        /// <param name="id">id do ServicoAplicacional buscado</param>
        /// <returns>O ServicoAplicacional buscado</returns>
        ServicoAplicacional Listarid(int id);

        /// <summary>
        /// Cadastra um novo ServicoAplicacional
        /// </summary>
        /// <param name="novoServicoAplicacional">Objeto novoServicoAplicacional com os novos dados</param>
        void Cadastrar(ServicoAplicacional novoServicoAplicacional);

        /// <summary>
        /// Atualiza um ServicoAplicacional existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="idServicoAplicacional">id do ServicoAplicacional que será atualizado</param>
        /// <param name="ServicoAplicacionalAtualizado">Objeto ServicoAplicacionalAtualizado com os novos dados</param>
        void Atualizar(int idServicoAplicacional, ServicoAplicacional ServicoAplicacionalAtualizado);

        /// <summary>
        /// Deleta um ServicoAplicacional existente
        /// </summary>
        /// <param name="idServicoAplicacional">id do ServicoAplicacional deletado</param>
        void Deletar(int idServicoAplicacional);
    }
}
