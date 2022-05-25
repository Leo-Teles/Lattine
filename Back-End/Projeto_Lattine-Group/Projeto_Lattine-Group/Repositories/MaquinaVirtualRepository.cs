using Microsoft.EntityFrameworkCore;
using Projeto_Lattine_Group.Contexts;
using Projeto_Lattine_Group.Domains;
using Projeto_Lattine_Group.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Projeto_Lattine_Group.Repositories
{
    public class MaquinaVirtualRepository : IMaquinaVirtualRepository
    {
        lattineContext ctx = new lattineContext();

        public void Atualizar(int idMaquinaVirtual, MaquinaVirtual MaquinaVirtualAtualizada)
        {
            MaquinaVirtual MaquinaVirtualBuscada = Listarid(idMaquinaVirtual);

            if (MaquinaVirtualBuscada != null)
            {
                MaquinaVirtualBuscada.NomeMaquinaVirtual = MaquinaVirtualAtualizada.NomeMaquinaVirtual;
                MaquinaVirtualBuscada.OpcoesDisponibilidade = MaquinaVirtualAtualizada.OpcoesDisponibilidade;
                MaquinaVirtualBuscada.SistemaOperacional = MaquinaVirtualAtualizada.SistemaOperacional;
                MaquinaVirtualBuscada.Tamanho = MaquinaVirtualAtualizada.Tamanho;
                MaquinaVirtualBuscada.NomeAdmin = MaquinaVirtualAtualizada.NomeAdmin;
                MaquinaVirtualBuscada.OrigemChavePublicaSsh = MaquinaVirtualAtualizada.OrigemChavePublicaSsh;
                MaquinaVirtualBuscada.IdUsuario = MaquinaVirtualAtualizada.IdUsuario;
                MaquinaVirtualBuscada.DataCadastro = MaquinaVirtualAtualizada.DataCadastro;
            }

            ctx.MaquinaVirtuals.Update(MaquinaVirtualBuscada);

            ctx.SaveChanges();
        }

        public void Cadastrar(MaquinaVirtual novaMaquinaVirtual)
        {
            ctx.MaquinaVirtuals.Add(novaMaquinaVirtual);

            ctx.SaveChanges();
        }

        public void Deletar(int idMaquinaVirtual)
        {
            MaquinaVirtual MaquinaVirtualBuscada = Listarid(idMaquinaVirtual);

            ctx.MaquinaVirtuals.Remove(MaquinaVirtualBuscada);

            ctx.SaveChanges();
        }

        public List<MaquinaVirtual> Listar()
        {
            return ctx.MaquinaVirtuals
            .Include(p => p.IdUsuarioNavigation)
            .ToList();
        }

        public MaquinaVirtual Listarid(int id)
        {
            return ctx.MaquinaVirtuals.FirstOrDefault(c => c.IdMaquinaVirtual == id);
        }

        public List<MaquinaVirtual> ListarMinhas(int id)
        {
            return ctx.MaquinaVirtuals
                .Include(p => p.IdUsuarioNavigation)
                .Where(p => p.IdUsuarioNavigation.IdUsuario == id)
                .ToList();
        }

        public List<MaquinaVirtual> ListarUma(int id)
        {
            return ctx.MaquinaVirtuals
                .Include(p => p.IdUsuarioNavigation)
                .Where(p => p.IdMaquinaVirtual == id)
                .ToList();
        }
    }
}