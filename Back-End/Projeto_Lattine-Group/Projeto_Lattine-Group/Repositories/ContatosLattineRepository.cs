using Projeto_Lattine_Group.Contexts;
using Projeto_Lattine_Group.Domains;
using Projeto_Lattine_Group.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Projeto_Lattine_Group.Repositories
{
    public class ContatosLattineRepository : IContatosLattineRepository
    {
        lattineContext ctx = new lattineContext();

        public void Atualizar(int idContatosLattine, ContatosLattine ContatosLattineAtualizada)
        {
            ContatosLattine ContatosLattineBuscada = Listarid(idContatosLattine);

            if (ContatosLattineBuscada != null)
            {
                ContatosLattineBuscada.Localizacao = ContatosLattineAtualizada.Localizacao;
            }

            ctx.ContatosLattines.Update(ContatosLattineBuscada);

            ctx.SaveChanges();
        }

        public void Cadastrar(ContatosLattine novaContatosLattine)
        {
            ctx.ContatosLattines.Add(novaContatosLattine);

            ctx.SaveChanges();
        }

        public void Deletar(int idContatosLattine)
        {
            ContatosLattine ContatosLattineBuscada = Listarid(idContatosLattine);

            ctx.ContatosLattines.Remove(ContatosLattineBuscada);

            ctx.SaveChanges();
        }

        public List<ContatosLattine> Listar()
        {
            return ctx.ContatosLattines.ToList();
        }

        public ContatosLattine Listarid(int id)
        {
            return ctx.ContatosLattines.FirstOrDefault(c => c.IdContatosLattine == id);
        }
    }
}
