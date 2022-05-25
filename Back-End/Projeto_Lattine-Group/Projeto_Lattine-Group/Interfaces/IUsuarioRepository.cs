using Projeto_Lattine_Group.Domains;
using System.Collections.Generic;

namespace Projeto_Lattine_Group.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório UsuarioRepository
    /// </summary>
    interface IUsuarioRepository
    {
        /// <summary>
        /// Lista todos os Usuarios
        /// </summary>
        /// <returns>Lista de Usuarios</returns>
        List<Usuario> Listar();

        /// <summary>
        /// Busca um Usuario através de seu id
        /// </summary>
        /// <param name="id">id do Usuario buscado</param>
        /// <returns>O Usuario buscado</returns>
        Usuario Listarid(int id);

        /// <summary>
        /// Cadastra um novo Usuario
        /// </summary>
        /// <param name="novoUsuario">Objeto novoUsuario com os novos dados</param>
        void Cadastrar(Usuario novoUsuario);

        /// <summary>
        /// Atualiza um Usuario existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="idUsuario">id do Usuario que será atualizado</param>
        /// <param name="UsuarioAtualizado">Objeto UsuarioAtualizado com os novos dados</param>
        void Atualizar(int idUsuario, Usuario UsuarioAtualizado);

        /// <summary>
        /// Deleta um Usuario existente
        /// </summary>
        /// <param name="idUsuario">id do Usuario deletado</param>
        void Deletar(int idUsuario);

        /// <summary>
        /// Busca um usuário através de seu email e senha
        /// </summary>
        /// <param name="email">Email do usuário buscado</param>
        /// <param name="senha">Senha do usuário buscado</param>
        /// <returns>Usuário buscado</returns>
        Usuario Login(string email, string senha);

        /// <summary>
        /// Lista todos os dados do usuário logado
        /// </summary>
        /// <param name="id">ID do usuário logado</param>
        /// <returns>Uma lista de dados do usuário</returns>
        List<Usuario> ListarMeus(int id);

        /// <summary>
        /// Lista um usuário
        /// </summary>
        /// <param name="id">ID do usuário</param>
        /// <returns>Um usuário</returns>
        List<Usuario> ListarUm(int id);
    }
}
