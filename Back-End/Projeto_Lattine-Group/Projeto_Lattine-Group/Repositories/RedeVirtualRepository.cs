using Microsoft.EntityFrameworkCore;
using Projeto_Lattine_Group.Contexts;
using Projeto_Lattine_Group.Domains;
using Projeto_Lattine_Group.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Projeto_Lattine_Group.Repositories
{
    public class RedeVirtualRepository : IRedeVirtualRepository
    {
        lattineContext ctx = new lattineContext();

        public void Atualizar(int idRedeVirtual, RedeVirtual RedeVirtualAtualizada)
        {
            RedeVirtual RedeVirtualBuscada = Listarid(idRedeVirtual);

            if (RedeVirtualBuscada != null)
            {
                RedeVirtualBuscada.IdEnderecoIp = RedeVirtualAtualizada.IdEnderecoIp;
                RedeVirtualBuscada.IdSubRede = RedeVirtualAtualizada.IdSubRede;
                RedeVirtualBuscada.NomeRedeVirtual = RedeVirtualAtualizada.NomeRedeVirtual;
                RedeVirtualBuscada.BastionHost = RedeVirtualAtualizada.BastionHost;
                RedeVirtualBuscada.ProtecaoDdoS = RedeVirtualAtualizada.ProtecaoDdoS;
                RedeVirtualBuscada.FireWall = RedeVirtualAtualizada.FireWall;
                RedeVirtualBuscada.IdUsuario = RedeVirtualAtualizada.IdUsuario;
                RedeVirtualBuscada.DataCadastro = RedeVirtualAtualizada.DataCadastro;

            }

            ctx.RedeVirtuals.Update(RedeVirtualBuscada);

            ctx.SaveChanges();
        }

        public void Cadastrar(RedeVirtual novaRedeVirtual)
        {
            ctx.RedeVirtuals.Add(novaRedeVirtual);

            ctx.SaveChanges();
        }

        public void Deletar(int idRedeVirtual)
        {
            RedeVirtual RedeVirtualBuscada = Listarid(idRedeVirtual);

            ctx.RedeVirtuals.Remove(RedeVirtualBuscada);

            ctx.SaveChanges();
        }

        public List<RedeVirtual> Listar()
        {
            return ctx.RedeVirtuals
            .Include(p => p.IdUsuarioNavigation)
            .ToList();
        }

        public RedeVirtual Listarid(int id)
        {
            return ctx.RedeVirtuals.FirstOrDefault(c => c.IdRedeVirtual == id);
        }

        public List<RedeVirtual> ListarMinhas(int id)
        {
            return ctx.RedeVirtuals
                .Include(p => p.IdUsuarioNavigation)
                .Where(p => p.IdUsuarioNavigation.IdUsuario == id)
                .ToList();
        }

        public List<RedeVirtual> ListarUma(int id)
        {
            return ctx.RedeVirtuals
                .Include(p => p.IdEnderecoIpNavigation)
                .Include(p => p.IdSubRedeNavigation)
                .Where(p => p.IdRedeVirtual == id)
                .ToList();
        }
    }
}