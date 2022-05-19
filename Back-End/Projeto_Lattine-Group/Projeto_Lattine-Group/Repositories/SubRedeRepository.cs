using Microsoft.EntityFrameworkCore;
using Projeto_Lattine_Group.Contexts;
using Projeto_Lattine_Group.Domains;
using Projeto_Lattine_Group.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Projeto_Lattine_Group.Repositories
{
    public class SubRedeRepository : ISubRedeRepository
    {
        lattineContext ctx = new lattineContext();

        public void Atualizar(int idSubRede, SubRede SubRedeAtualizada)
        {
            SubRede SubRedeBuscada = Listarid(idSubRede);

            if (SubRedeBuscada != null)
            {
                SubRedeBuscada.NomeSubRede = SubRedeAtualizada.NomeSubRede;
                SubRedeBuscada.IntervalosEndereco = SubRedeAtualizada.IntervalosEndereco;
                SubRedeBuscada.IdUsuario = SubRedeAtualizada.IdUsuario;
            }

            ctx.SubRedes.Update(SubRedeBuscada);

            ctx.SaveChanges();
        }

        public void Cadastrar(SubRede novaSubRede)
        {
            ctx.SubRedes.Add(novaSubRede);

            ctx.SaveChanges();
        }

        public void Deletar(int idSubRede)
        {
            SubRede SubRedeBuscada = Listarid(idSubRede);

            ctx.SubRedes.Remove(SubRedeBuscada);

            ctx.SaveChanges();
        }

        public List<SubRede> Listar()
        {
            return ctx.SubRedes.ToList();
        }

        public SubRede Listarid(int id)
        {
            return ctx.SubRedes.FirstOrDefault(c => c.IdSubRede == id);
        }

        public List<SubRede> ListarMinhas(int id)
        {
            return ctx.SubRedes
                .Include(p => p.IdUsuarioNavigation)
                .Where(p => p.IdUsuarioNavigation.IdUsuario == id)
                .ToList();
        }
    }
}