using Microsoft.EntityFrameworkCore;
using Projeto_Lattine_Group.Contexts;
using Projeto_Lattine_Group.Domains;
using Projeto_Lattine_Group.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Projeto_Lattine_Group.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        lattineContext ctx = new lattineContext();

        public void Atualizar(int idUsuario, Usuario UsuarioAtualizada)
        {
            Usuario UsuarioBuscada = Listarid(idUsuario);

            if (UsuarioBuscada != null)
            {
                UsuarioBuscada.IdTipoUsuario = UsuarioAtualizada.IdTipoUsuario;
                UsuarioBuscada.Nome = UsuarioAtualizada.Nome;
                UsuarioBuscada.Sobrenome = UsuarioAtualizada.Sobrenome;
                UsuarioBuscada.Email = UsuarioAtualizada.Email;
                UsuarioBuscada.Senha = UsuarioAtualizada.Senha;
                UsuarioBuscada.DataCadastro = UsuarioAtualizada.DataCadastro;
            }

            ctx.Usuarios.Update(UsuarioBuscada);

            ctx.SaveChanges();
        }

        public void Cadastrar(Usuario novaUsuario)
        {
            ctx.Usuarios.Add(novaUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(int idUsuario)
        {
            Usuario UsuarioBuscada = Listarid(idUsuario);

            ctx.Usuarios.Remove(UsuarioBuscada);

            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuarios.ToList();
        }

        public Usuario Listarid(int id)
        {
            return ctx.Usuarios.FirstOrDefault(c => c.IdUsuario == id);
        }

        public Usuario Login(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(x => x.Email == email && x.Senha == senha);
        }

        public List<Usuario> ListarMeus(int id)
        {
            return ctx.Usuarios
                .Where(p => p.IdUsuario == id)
                .ToList();
        }

        public List<Usuario> ListarUm(int id)
        {
            return ctx.Usuarios
                .Where(p => p.IdUsuario == id)
                .ToList();
        }
    }
}