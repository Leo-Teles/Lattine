using Projeto_Lattine_Group.Contexts;
using Projeto_Lattine_Group.Domains;
using Projeto_Lattine_Group.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Projeto_Lattine_Group.Repositories
{
    public class TelefoneRepository : ITelefoneRepository
    {
        lattineContext ctx = new lattineContext();

        public void Atualizar(int idTelefone, Telefone TelefoneAtualizada)
        {
            Telefone TelefoneBuscada = Listarid(idTelefone);

            if (TelefoneBuscada != null)
            {
                TelefoneBuscada.Numero = TelefoneAtualizada.Numero;
                TelefoneBuscada.IdContatosLattine = TelefoneAtualizada.IdContatosLattine;
            }

            ctx.Telefones.Update(TelefoneBuscada);

            ctx.SaveChanges();
        }

        public void Cadastrar(Telefone novaTelefone)
        {
            ctx.Telefones.Add(novaTelefone);

            ctx.SaveChanges();
        }

        public void Deletar(int idTelefone)
        {
            Telefone TelefoneBuscada = Listarid(idTelefone);

            ctx.Telefones.Remove(TelefoneBuscada);

            ctx.SaveChanges();
        }

        public List<Telefone> Listar()
        {
            return ctx.Telefones.ToList();
        }

        public Telefone Listarid(int id)
        {
            return ctx.Telefones.FirstOrDefault(c => c.IdTelefone == id);
        }
    }
}