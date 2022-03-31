using Projeto_Lattine_Group.Contexts;
using Projeto_Lattine_Group.Domains;
using Projeto_Lattine_Group.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Projeto_Lattine_Group.Repositories
{
    public class GrupoInfraestruturaRepository : IGrupoInfraestruturaRepository
    {
        lattineContext ctx = new lattineContext();

        public void Atualizar(int idGrupoInfraestrutura, GrupoInfraestrutura GrupoInfraestruturaAtualizada)
        {
            GrupoInfraestrutura GrupoInfraestruturaBuscada = Listarid(idGrupoInfraestrutura);

            if (GrupoInfraestruturaBuscada != null)
            {
                GrupoInfraestruturaBuscada.IdInfraestrutura = GrupoInfraestruturaAtualizada.IdInfraestrutura;
                GrupoInfraestruturaBuscada.IdGrupoRecursos = GrupoInfraestruturaAtualizada.IdGrupoRecursos;
            }

            ctx.GrupoInfraestruturas.Update(GrupoInfraestruturaBuscada);

            ctx.SaveChanges();
        }

        public void Cadastrar(GrupoInfraestrutura novaGrupoInfraestrutura)
        {
            ctx.GrupoInfraestruturas.Add(novaGrupoInfraestrutura);

            ctx.SaveChanges();
        }

        public void Deletar(int idGrupoInfraestrutura)
        {
            GrupoInfraestrutura GrupoInfraestruturaBuscada = Listarid(idGrupoInfraestrutura);

            ctx.GrupoInfraestruturas.Remove(GrupoInfraestruturaBuscada);

            ctx.SaveChanges();
        }

        public List<GrupoInfraestrutura> Listar()
        {
            return ctx.GrupoInfraestruturas.ToList();
        }

        public GrupoInfraestrutura Listarid(int id)
        {
            return ctx.GrupoInfraestruturas.FirstOrDefault(c => c.IdGrupoInfraestrutura == id);
        }
    }
}