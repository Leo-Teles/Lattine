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
    public class RedeVirtualsController : ControllerBase
    {
        private IRedeVirtualRepository _RedeVirtualRepository { get; set; }

        public RedeVirtualsController()
        {
            _RedeVirtualRepository = new RedeVirtualRepository();
        }

        /// <summary>
        /// Lista todos os RedeVirtuals
        /// </summary>
        /// <returns>Uma lista de RedeVirtuals com um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            List<RedeVirtual> listaRedeVirtuals = _RedeVirtualRepository.Listar();
            return Ok(listaRedeVirtuals);
        }

        /// <summary>
        /// Busca um RedeVirtual através de seu ID
        /// </summary>
        /// <param name="id">ID do RedeVirtual buscado</param>
        /// <returns>O RedeVirtual buscado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            RedeVirtual RedeVirtualBuscado = _RedeVirtualRepository.Listarid(id);

            if (RedeVirtualBuscado == null)
            {
                return NotFound("Nenhum RedeVirtual encontrado.");
            }

            return Ok(RedeVirtualBuscado);
        }

        /// <summary>
        /// Cadastra um novo RedeVirtual
        /// </summary>
        /// <param name="novoRedeVirtual">Objeto novoRedeVirtual com os novos dados</param>
        [HttpPost]
        public IActionResult Post(RedeVirtual novoRedeVirtual)
        {
            _RedeVirtualRepository.Cadastrar(novoRedeVirtual);

            return StatusCode(201);
        }

        /// <summary>
        /// Deleta um RedeVirtual existente
        /// </summary>
        /// <param name="id">ID do RedeVirtual deletado</param>
        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _RedeVirtualRepository.Deletar(id);
            return StatusCode(204);
        }

        /// <summary>
        /// Atualiza um RedeVirtual existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="id">id do RedeVirtual que será atualizado</param>
        /// <param name="RedeVirtualAtualizado">Objeto RedeVirtualAtualizado com os novos dados</param>
        [HttpPut("{id}")]
        public IActionResult Put(int id, RedeVirtual RedeVirtualAtualizado)
        {
            RedeVirtual RedeVirtualBuscado = _RedeVirtualRepository.Listarid(id);

            if (RedeVirtualBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "RedeVirtual não encontrado.",
                        erro = true
                    });
            }

            try
            {
                _RedeVirtualRepository.Atualizar(id, RedeVirtualAtualizado);

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

                return Ok(_RedeVirtualRepository.ListarMinhas(id));
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

        [HttpGet("uma/{id}")]
        public IActionResult ListarUma(int id)
        {
            try
            {
                RedeVirtual RedeVirtualBuscado = _RedeVirtualRepository.Listarid(id);

                return Ok(_RedeVirtualRepository.ListarUma(id));
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