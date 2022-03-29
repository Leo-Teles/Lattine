using Projeto_Lattine_Group.Contexts;
using Projeto_Lattine_Group.Domains;
using Projeto_Lattine_Group.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Projeto_Lattine_Group.Repositories
{
    public class EnderecoIPRepository : IEnderecoIPRepository
    {
        lattineContext ctx = new lattineContext();

        public void Atualizar(int idEnderecoIP, EnderecoIp EnderecoIPAtualizada)
        {
            EnderecoIp EnderecoIPBuscada = Listarid(idEnderecoIP);

            if (EnderecoIPBuscada != null)
            {
                EnderecoIPBuscada.Endereco = EnderecoIPAtualizada.Endereco;
            }

            ctx.EnderecoIps.Update(EnderecoIPBuscada);

            ctx.SaveChanges();
        }

        public void Cadastrar(EnderecoIp novaEnderecoIP)
        {
            ctx.EnderecoIps.Add(novaEnderecoIP);

            ctx.SaveChanges();
        }

        public void Deletar(int idEnderecoIP)
        {
            EnderecoIp EnderecoIPBuscada = Listarid(idEnderecoIP);

            ctx.EnderecoIps.Remove(EnderecoIPBuscada);

            ctx.SaveChanges();
        }

        public List<EnderecoIp> Listar()
        {
            return ctx.EnderecoIps.ToList();
        }

        public EnderecoIp Listarid(int id)
        {
            return ctx.EnderecoIps.FirstOrDefault(c => c.IdEnderecoIp == id);
        }
    }
}
