using Projeto_Lattine_Group.Domains;
using System.Collections.Generic;

namespace Projeto_Lattine_Group.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório TelefoneRepository
    /// </summary>
    interface ITelefoneRepository
    {
        /// <summary>
        /// Lista todos os Telefones
        /// </summary>
        /// <returns>Lista de Telefones</returns>
        List<Telefone> Listar();

        /// <summary>
        /// Busca um Telefone através de seu id
        /// </summary>
        /// <param name="id">id do Telefone buscado</param>
        /// <returns>O Telefone buscado</returns>
        Telefone Listarid(int id);

        /// <summary>
        /// Cadastra um novo Telefone
        /// </summary>
        /// <param name="novoTelefone">Objeto novoTelefone com os novos dados</param>
        void Cadastrar(Telefone novoTelefone);

        /// <summary>
        /// Atualiza um Telefone existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="idTelefone">id do Telefone que será atualizado</param>
        /// <param name="TelefoneAtualizado">Objeto TelefoneAtualizado com os novos dados</param>
        void Atualizar(int idTelefone, Telefone TelefoneAtualizado);

        /// <summary>
        /// Deleta um Telefone existente
        /// </summary>
        /// <param name="idTelefone">id do Telefone deletado</param>
        void Deletar(int idTelefone);
    }
}
