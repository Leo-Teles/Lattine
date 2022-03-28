using Projeto_Lattine_Group.Domains;
using System.Collections.Generic;

namespace Projeto_Lattine_Group.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório TipoUsuarioRepository
    /// </summary>
    interface ITipoUsuarioRepository
    {
        /// <summary>
        /// Lista todos os TipoUsuarios
        /// </summary>
        /// <returns>Lista de TipoUsuarios</returns>
        List<TipoUsuario> Listar();

        /// <summary>
        /// Busca um TipoUsuario através de seu id
        /// </summary>
        /// <param name="id">id do TipoUsuario buscado</param>
        /// <returns>O TipoUsuario buscado</returns>
        TipoUsuario Listarid(int id);

        /// <summary>
        /// Cadastra um novo TipoUsuario
        /// </summary>
        /// <param name="novoTipoUsuario">Objeto novoTipoUsuario com os novos dados</param>
        void Cadastrar(TipoUsuario novoTipoUsuario);

        /// <summary>
        /// Atualiza um TipoUsuario existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="idTipoUsuario">id do TipoUsuario que será atualizado</param>
        /// <param name="TipoUsuarioAtualizado">Objeto TipoUsuarioAtualizado com os novos dados</param>
        void Atualizar(int idTipoUsuario, TipoUsuario TipoUsuarioAtualizado);

        /// <summary>
        /// Deleta um TipoUsuario existente
        /// </summary>
        /// <param name="idTipoUsuario">id do TipoUsuario deletado</param>
        void Deletar(int idTipoUsuario);
    }
}
