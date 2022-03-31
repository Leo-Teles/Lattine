using Projeto_Lattine_Group.Contexts;
using Projeto_Lattine_Group.Domains;
using Projeto_Lattine_Group.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Projeto_Lattine_Group.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        lattineContext ctx = new lattineContext();

        public void Atualizar(int idTipoUsuario, TipoUsuario TipoUsuarioAtualizada)
        {
            TipoUsuario TipoUsuarioBuscada = Listarid(idTipoUsuario);

            if (TipoUsuarioBuscada != null)
            {
                TipoUsuarioBuscada.Titulo = TipoUsuarioAtualizada.Titulo;
            }

            ctx.TipoUsuarios.Update(TipoUsuarioBuscada);

            ctx.SaveChanges();
        }

        public void Cadastrar(TipoUsuario novaTipoUsuario)
        {
            ctx.TipoUsuarios.Add(novaTipoUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(int idTipoUsuario)
        {
            TipoUsuario TipoUsuarioBuscada = Listarid(idTipoUsuario);

            ctx.TipoUsuarios.Remove(TipoUsuarioBuscada);

            ctx.SaveChanges();
        }

        public List<TipoUsuario> Listar()
        {
            return ctx.TipoUsuarios.ToList();
        }

        public TipoUsuario Listarid(int id)
        {
            return ctx.TipoUsuarios.FirstOrDefault(c => c.IdTipoUsuario == id);
        }
    }
}