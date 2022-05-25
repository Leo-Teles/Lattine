using Projeto_Lattine_Group.Domains;
using System.Collections.Generic;

namespace Projeto_Lattine_Group.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório MaquinaVirtualRepository
    /// </summary>
    interface IMaquinaVirtualRepository
    {
        /// <summary>
        /// Lista todas as MaquinaVirtuals
        /// </summary>
        /// <returns>Lista de MaquinaVirtuals</returns>
        List<MaquinaVirtual> Listar();

        /// <summary>
        /// Busca uma MaquinaVirtual através de seu id
        /// </summary>
        /// <param name="id">id da MaquinaVirtual buscada</param>
        /// <returns>A MaquinaVirtual buscada</returns>
        MaquinaVirtual Listarid(int id);

        /// <summary>
        /// Cadastra uma nova MaquinaVirtual
        /// </summary>
        /// <param name="novaMaquinaVirtual">Objeto novaMaquinaVirtual com os novos dados</param>
        void Cadastrar(MaquinaVirtual novaMaquinaVirtual);

        /// <summary>
        /// Atualiza uma MaquinaVirtual existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="idMaquinaVirtual">id da MaquinaVirtual que será atualizada</param>
        /// <param name="MaquinaVirtualAtualizada">Objeto MaquinaVirtualAtualizada com os novos dados</param>
        void Atualizar(int idMaquinaVirtual, MaquinaVirtual MaquinaVirtualAtualizada);

        /// <summary>
        /// Deleta uma MaquinaVirtual existente
        /// </summary>
        /// <param name="idMaquinaVirtual">id da MaquinaVirtual deletada</param>
        void Deletar(int idMaquinaVirtual);

        /// <summary>
        /// Lista todas as máquinas virtuais do usuário logado
        /// </summary>
        /// <param name="id">ID do usuário logado</param>
        /// <returns>Uma lista de máquinas virtuais do usuário</returns>
        List<MaquinaVirtual> ListarMinhas(int id);

        /// <summary>
        /// Lista uma máquina virtual
        /// </summary>
        /// <param name="id">ID da máquina virtual</param>
        /// <returns>Uma máquina virtual</returns>
        List<MaquinaVirtual> ListarUma(int id);
    }
}
