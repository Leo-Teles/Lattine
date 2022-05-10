using Microsoft.EntityFrameworkCore;
using Projeto_Lattine_Group.Contexts;
using Projeto_Lattine_Group.Domains;
using Projeto_Lattine_Group.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Projeto_Lattine_Group.Repositories
{
    public class InfraestruturaRepository : IInfraestruturaRepository
    {
        lattineContext ctx = new lattineContext();

        public void Atualizar(int idInfraestrutura, Infraestrutura InfraestruturaAtualizada)
        {
            Infraestrutura InfraestruturaBuscada = Listarid(idInfraestrutura);

            if (InfraestruturaBuscada != null)
            {
                InfraestruturaBuscada.DataCadastro = InfraestruturaAtualizada.DataCadastro;
            }

            ctx.Infraestruturas.Update(InfraestruturaBuscada);

            ctx.SaveChanges();
        }

        public void Cadastrar(Infraestrutura novaInfraestrutura)
        {
            ctx.Infraestruturas.Add(novaInfraestrutura);

            ctx.SaveChanges();
        }

        public void Deletar(int idInfraestrutura)
        {
            Infraestrutura InfraestruturaBuscada = Listarid(idInfraestrutura);

            ctx.Infraestruturas.Remove(InfraestruturaBuscada);

            ctx.SaveChanges();
        }

        public List<Infraestrutura> Listar()
        {
            return ctx.Infraestruturas.ToList();
        }

        public Infraestrutura Listarid(int id)
        {
            return ctx.Infraestruturas.FirstOrDefault(c => c.IdInfraestrutura == id);
        }
    }
}