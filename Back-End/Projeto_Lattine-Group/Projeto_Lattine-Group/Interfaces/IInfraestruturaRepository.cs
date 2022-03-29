using Projeto_Lattine_Group.Domains;
using System.Collections.Generic;

namespace Projeto_Lattine_Group.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório InfraestruturaRepository
    /// </summary>
    interface IInfraestruturaRepository
    {
        /// <summary>
        /// Lista todas as Infraestruturas
        /// </summary>
        /// <returns>Lista de Infraestruturas</returns>
        List<Infraestrutura> Listar();

        /// <summary>
        /// Busca uma Infraestrutura através de seu id
        /// </summary>
        /// <param name="id">id da Infraestrutura buscada</param>
        /// <returns>A Infraestrutura buscada</returns>
        Infraestrutura Listarid(int id);

        /// <summary>
        /// Cadastra uma nova Infraestrutura
        /// </summary>
        /// <param name="novaInfraestrutura">Objeto novaInfraestrutura com os novos dados</param>
        void Cadastrar(Infraestrutura novaInfraestrutura);

        /// <summary>
        /// Atualiza uma Infraestrutura existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="idInfraestrutura">id da Infraestrutura que será atualizada</param>
        /// <param name="InfraestruturaAtualizada">Objeto InfraestruturaAtualizada com os novos dados</param>
        void Atualizar(int idInfraestrutura, Infraestrutura InfraestruturaAtualizada);

        /// <summary>
        /// Deleta uma Infraestrutura existente
        /// </summary>
        /// <param name="idInfraestrutura">id da Infraestrutura deletada</param>
        void Deletar(int idInfraestrutura);
    }
}
