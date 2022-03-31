using Projeto_Lattine_Group.Contexts;
using Projeto_Lattine_Group.Domains;
using Projeto_Lattine_Group.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Projeto_Lattine_Group.Repositories
{
    public class GrupoRecursoRepository : IGrupoRecursoRepository
    {
        lattineContext ctx = new lattineContext();

        public void Atualizar(int idGrupoRecurso, GrupoRecurso GrupoRecursoAtualizada)
        {
            GrupoRecurso GrupoRecursoBuscada = Listarid(idGrupoRecurso);

            if (GrupoRecursoBuscada != null)
            {
                GrupoRecursoBuscada.IdUsuario = GrupoRecursoAtualizada.IdUsuario;
                GrupoRecursoBuscada.NomeGrupoRecursos = GrupoRecursoAtualizada.NomeGrupoRecursos;
                GrupoRecursoBuscada.DataCadastro = GrupoRecursoAtualizada.DataCadastro;
            }

            ctx.GrupoRecursos.Update(GrupoRecursoBuscada);

            ctx.SaveChanges();
        }

        public void Cadastrar(GrupoRecurso novaGrupoRecurso)
        {
            ctx.GrupoRecursos.Add(novaGrupoRecurso);

            ctx.SaveChanges();
        }

        public void Deletar(int idGrupoRecurso)
        {
            GrupoRecurso GrupoRecursoBuscada = Listarid(idGrupoRecurso);

            ctx.GrupoRecursos.Remove(GrupoRecursoBuscada);

            ctx.SaveChanges();
        }

        public List<GrupoRecurso> Listar()
        {
            return ctx.GrupoRecursos.ToList();
        }

        public GrupoRecurso Listarid(int id)
        {
            return ctx.GrupoRecursos.FirstOrDefault(c => c.IdGrupoRecursos == id);
        }
    }
}