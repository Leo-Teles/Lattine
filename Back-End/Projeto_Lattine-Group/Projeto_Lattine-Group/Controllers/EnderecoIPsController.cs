using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projeto_Lattine_Group.Domains;
using Projeto_Lattine_Group.Interfaces;
using Projeto_Lattine_Group.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace Projeto_Lattine_Group.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoIPsController : ControllerBase
    {
        private IEnderecoIPRepository _EnderecoIPRepository { get; set; }

        public EnderecoIPsController()
        {
            _EnderecoIPRepository = new EnderecoIPRepository();
        }

        /// <summary>
        /// Lista todos os EnderecoIPs
        /// </summary>
        /// <returns>Uma lista de EnderecoIPs com um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            List<EnderecoIp> listaEnderecoIPs = _EnderecoIPRepository.Listar();
            return Ok(listaEnderecoIPs);
        }

        /// <summary>
        /// Busca um EnderecoIP através de seu ID
        /// </summary>
        /// <param name="id">ID do EnderecoIP buscado</param>
        /// <returns>O EnderecoIP buscado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            EnderecoIp EnderecoIPBuscado = _EnderecoIPRepository.Listarid(id);

            if (EnderecoIPBuscado == null)
            {
                return NotFound("Nenhum EnderecoIP encontrado.");
            }

            return Ok(EnderecoIPBuscado);
        }

        /// <summary>
        /// Cadastra um novo EnderecoIP
        /// </summary>
        /// <param name="novoEnderecoIP">Objeto novoEnderecoIP com os novos dados</param>
        [HttpPost]
        public IActionResult Post(EnderecoIp novoEnderecoIP)
        {
            _EnderecoIPRepository.Cadastrar(novoEnderecoIP);

            return StatusCode(201);
        }

        /// <summary>
        /// Deleta um EnderecoIP existente
        /// </summary>
        /// <param name="id">ID do EnderecoIP deletado</param>
        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _EnderecoIPRepository.Deletar(id);
            return StatusCode(204);
        }

        /// <summary>
        /// Atualiza um EnderecoIP existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="id">id do EnderecoIP que será atualizado</param>
        /// <param name="EnderecoIPAtualizado">Objeto EnderecoIPAtualizado com os novos dados</param>
        [HttpPut("{id}")]
        public IActionResult Put(int id, EnderecoIp EnderecoIPAtualizado)
        {
            EnderecoIp EnderecoIPBuscado = _EnderecoIPRepository.Listarid(id);

            if (EnderecoIPBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "EnderecoIP não encontrado.",
                        erro = true
                    });
            }

            try
            {
                _EnderecoIPRepository.Atualizar(id, EnderecoIPAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet("meus")]
        public IActionResult ListarMeus()
        {
            try
            {
                int id = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                return Ok(_EnderecoIPRepository.ListarMeus(id));
            }
            catch (Exception error)
            {
                return BadRequest(new
                {
                    mensagem = "Não é possível mostrar os dados se o usuário não estiver logado!",
                    erro = error

                });
            }
        }
    }
}