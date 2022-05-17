using Microsoft.EntityFrameworkCore;
using Projeto_Lattine_Group.Contexts;
using Projeto_Lattine_Group.Domains;
using Projeto_Lattine_Group.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Projeto_Lattine_Group.Repositories
{
    public class ServicoAplicacionalRepository : IServicoAplicacionalRepository
    {
        lattineContext ctx = new lattineContext();

        public void Atualizar(int idServicoAplicacional, ServicoAplicacional ServicoAplicacionalAtualizada)
        {
            ServicoAplicacional ServicoAplicacionalBuscada = Listarid(idServicoAplicacional);

            if (ServicoAplicacionalBuscada != null)
            {
                ServicoAplicacionalBuscada.IdInfraestrutura = ServicoAplicacionalAtualizada.IdInfraestrutura;
                ServicoAplicacionalBuscada.NomeServicoAplicacional = ServicoAplicacionalAtualizada.NomeServicoAplicacional;
                ServicoAplicacionalBuscada.PilhaRuntime = ServicoAplicacionalAtualizada.PilhaRuntime;
                ServicoAplicacionalBuscada.SkueTamanho = ServicoAplicacionalAtualizada.SkueTamanho;
            }

            ctx.ServicoAplicacionals.Update(ServicoAplicacionalBuscada);

            ctx.SaveChanges();
        }

        public void Cadastrar(ServicoAplicacional novaServicoAplicacional)
        {
            ctx.ServicoAplicacionals.Add(novaServicoAplicacional);

            ctx.SaveChanges();
        }

        public void Deletar(int idServicoAplicacional)
        {
            ServicoAplicacional ServicoAplicacionalBuscada = Listarid(idServicoAplicacional);

            ctx.ServicoAplicacionals.Remove(ServicoAplicacionalBuscada);

            ctx.SaveChanges();
        }

        public List<ServicoAplicacional> Listar()
        {
            return ctx.ServicoAplicacionals
            .Include(p => p.IdInfraestruturaNavigation)
            .Include(p => p.IdInfraestruturaNavigation.IdUsuarioNavigation)
            .ToList();
        }

        public ServicoAplicacional Listarid(int id)
        {
            return ctx.ServicoAplicacionals.FirstOrDefault(c => c.IdServicoAplicacional == id);
        }

        public List<ServicoAplicacional> ListarMeus(int id)
        {
            return ctx.ServicoAplicacionals
                .Include(p => p.IdInfraestruturaNavigation)
                .Include(p => p.IdInfraestruturaNavigation.IdUsuarioNavigation)
                .Where(p => p.IdInfraestruturaNavigation.IdUsuarioNavigation.IdUsuario == id)
                .ToList();
        }
    }
}