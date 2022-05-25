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
    public class ServicoAplicacionalsController : ControllerBase
    {
        private IServicoAplicacionalRepository _ServicoAplicacionalRepository { get; set; }

        public ServicoAplicacionalsController()
        {
            _ServicoAplicacionalRepository = new ServicoAplicacionalRepository();
        }

        /// <summary>
        /// Lista todos os ServicoAplicacionals
        /// </summary>
        /// <returns>Uma lista de ServicoAplicacionals com um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            List<ServicoAplicacional> listaServicoAplicacionals = _ServicoAplicacionalRepository.Listar();
            return Ok(listaServicoAplicacionals);
        }

        /// <summary>
        /// Busca um ServicoAplicacional através de seu ID
        /// </summary>
        /// <param name="id">ID do ServicoAplicacional buscado</param>
        /// <returns>O ServicoAplicacional buscado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            ServicoAplicacional ServicoAplicacionalBuscado = _ServicoAplicacionalRepository.Listarid(id);

            if (ServicoAplicacionalBuscado == null)
            {
                return NotFound("Nenhum ServicoAplicacional encontrado.");
            }

            return Ok(ServicoAplicacionalBuscado);
        }

        /// <summary>
        /// Cadastra um novo ServicoAplicacional
        /// </summary>
        /// <param name="novoServicoAplicacional">Objeto novoServicoAplicacional com os novos dados</param>
        [HttpPost]
        public IActionResult Post(ServicoAplicacional novoServicoAplicacional)
        {
            _ServicoAplicacionalRepository.Cadastrar(novoServicoAplicacional);

            return StatusCode(201);
        }

        /// <summary>
        /// Deleta um ServicoAplicacional existente
        /// </summary>
        /// <param name="id">ID do ServicoAplicacional deletado</param>
        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _ServicoAplicacionalRepository.Deletar(id);
            return StatusCode(204);
        }

        /// <summary>
        /// Atualiza um ServicoAplicacional existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="id">id do ServicoAplicacional que será atualizado</param>
        /// <param name="ServicoAplicacionalAtualizado">Objeto ServicoAplicacionalAtualizado com os novos dados</param>
        [HttpPut("{id}")]
        public IActionResult Put(int id, ServicoAplicacional ServicoAplicacionalAtualizado)
        {
            ServicoAplicacional ServicoAplicacionalBuscado = _ServicoAplicacionalRepository.Listarid(id);

            if (ServicoAplicacionalBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "ServicoAplicacional não encontrado.",
                        erro = true
                    });
            }

            try
            {
                _ServicoAplicacionalRepository.Atualizar(id, ServicoAplicacionalAtualizado);

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

                return Ok(_ServicoAplicacionalRepository.ListarMeus(id));
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

        [HttpGet("um/{id}")]
        public IActionResult ListarUm(int id)
        {
            try
            {
                ServicoAplicacional ServicoAplicacionalBuscado = _ServicoAplicacionalRepository.Listarid(id);

                return Ok(_ServicoAplicacionalRepository.ListarUm(id));
            }
            catch (Exception error)
            {
                return BadRequest(new
                {
                    mensagem = "Não é possível mostrar os dados sem o id.",
                    erro = error

                });
            }
        }
    }
}