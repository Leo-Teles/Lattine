using Projeto_Lattine_Group.Domains;
using System.Collections.Generic;

namespace Projeto_Lattine_Group.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório ContatosLattineRepository
    /// </summary>
    interface IContatosLattineRepository
    {
        /// <summary>
        /// Lista todos os ContatosLattines
        /// </summary>
        /// <returns>Lista de ContatosLattines</returns>
        List<ContatosLattine> Listar();

        /// <summary>
        /// Busca um ContatosLattine através de seu id
        /// </summary>
        /// <param name="id">id do ContatosLattine buscado</param>
        /// <returns>O ContatosLattine buscado</returns>
        ContatosLattine Listarid(int id);

        /// <summary>
        /// Cadastra um novo ContatosLattine
        /// </summary>
        /// <param name="novoContatosLattine">Objeto novoContatosLattine com os novos dados</param>
        void Cadastrar(ContatosLattine novoContatosLattine);

        /// <summary>
        /// Atualiza um ContatosLattine existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="idContatosLattine">id do ContatosLattine que será atualizado</param>
        /// <param name="ContatosLattineAtualizado">Objeto ContatosLattineAtualizado com os novos dados</param>
        void Atualizar(int idContatosLattine, ContatosLattine ContatosLattineAtualizado);

        /// <summary>
        /// Deleta um ContatosLattine existente
        /// </summary>
        /// <param name="idContatosLattine">id do ContatosLattine deletado</param>
        void Deletar(int idContatosLattine);
    }
}
