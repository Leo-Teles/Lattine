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
    public class SubRedesController : ControllerBase
    {
        private ISubRedeRepository _SubRedeRepository { get; set; }

        public SubRedesController()
        {
            _SubRedeRepository = new SubRedeRepository();
        }

        /// <summary>
        /// Lista todos os SubRedes
        /// </summary>
        /// <returns>Uma lista de SubRedes com um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            List<SubRede> listaSubRedes = _SubRedeRepository.Listar();
            return Ok(listaSubRedes);
        }

        /// <summary>
        /// Busca um SubRede através de seu ID
        /// </summary>
        /// <param name="id">ID do SubRede buscado</param>
        /// <returns>O SubRede buscado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            SubRede SubRedeBuscado = _SubRedeRepository.Listarid(id);

            if (SubRedeBuscado == null)
            {
                return NotFound("Nenhum SubRede encontrado.");
            }

            return Ok(SubRedeBuscado);
        }

        /// <summary>
        /// Cadastra um novo SubRede
        /// </summary>
        /// <param name="novoSubRede">Objeto novoSubRede com os novos dados</param>
        [HttpPost]
        public IActionResult Post(SubRede novoSubRede)
        {
            _SubRedeRepository.Cadastrar(novoSubRede);

            return StatusCode(201);
        }

        /// <summary>
        /// Deleta um SubRede existente
        /// </summary>
        /// <param name="id">ID do SubRede deletado</param>
        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _SubRedeRepository.Deletar(id);
            return StatusCode(204);
        }

        /// <summary>
        /// Atualiza um SubRede existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="id">id do SubRede que será atualizado</param>
        /// <param name="SubRedeAtualizado">Objeto SubRedeAtualizado com os novos dados</param>
        [HttpPut("{id}")]
        public IActionResult Put(int id, SubRede SubRedeAtualizado)
        {
            SubRede SubRedeBuscado = _SubRedeRepository.Listarid(id);

            if (SubRedeBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "SubRede não encontrado.",
                        erro = true
                    });
            }

            try
            {
                _SubRedeRepository.Atualizar(id, SubRedeAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet("minhas")]
        public IActionResult ListarMinhas()
        {
            try
            {
                int id = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                return Ok(_SubRedeRepository.ListarMinhas(id));
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