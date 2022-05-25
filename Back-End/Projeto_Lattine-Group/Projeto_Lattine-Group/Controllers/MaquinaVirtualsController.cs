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
    public class MaquinaVirtualsController : ControllerBase
    {
        private IMaquinaVirtualRepository _MaquinaVirtualRepository { get; set; }

        public MaquinaVirtualsController()
        {
            _MaquinaVirtualRepository = new MaquinaVirtualRepository();
        }

        /// <summary>
        /// Lista todos os MaquinaVirtuals
        /// </summary>
        /// <returns>Uma lista de MaquinaVirtuals com um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            List<MaquinaVirtual> listaMaquinaVirtuals = _MaquinaVirtualRepository.Listar();
            return Ok(listaMaquinaVirtuals);
        }

        /// <summary>
        /// Busca um MaquinaVirtual através de seu ID
        /// </summary>
        /// <param name="id">ID do MaquinaVirtual buscado</param>
        /// <returns>O MaquinaVirtual buscado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            MaquinaVirtual MaquinaVirtualBuscado = _MaquinaVirtualRepository.Listarid(id);

            if (MaquinaVirtualBuscado == null)
            {
                return NotFound("Nenhum MaquinaVirtual encontrado.");
            }

            return Ok(MaquinaVirtualBuscado);
        }

        /// <summary>
        /// Cadastra um novo MaquinaVirtual
        /// </summary>
        /// <param name="novoMaquinaVirtual">Objeto novoMaquinaVirtual com os novos dados</param>
        [HttpPost]
        public IActionResult Post(MaquinaVirtual novoMaquinaVirtual)
        {
            _MaquinaVirtualRepository.Cadastrar(novoMaquinaVirtual);

            return StatusCode(201);
        }

        /// <summary>
        /// Deleta um MaquinaVirtual existente
        /// </summary>
        /// <param name="id">ID do MaquinaVirtual deletado</param>
        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _MaquinaVirtualRepository.Deletar(id);
            return StatusCode(204);
        }

        /// <summary>
        /// Atualiza um MaquinaVirtual existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="id">id do MaquinaVirtual que será atualizado</param>
        /// <param name="MaquinaVirtualAtualizado">Objeto MaquinaVirtualAtualizado com os novos dados</param>
        [HttpPut("{id}")]
        public IActionResult Put(int id, MaquinaVirtual MaquinaVirtualAtualizado)
        {
            MaquinaVirtual MaquinaVirtualBuscado = _MaquinaVirtualRepository.Listarid(id);

            if (MaquinaVirtualBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "MaquinaVirtual não encontrado.",
                        erro = true
                    });
            }

            try
            {
                _MaquinaVirtualRepository.Atualizar(id, MaquinaVirtualAtualizado);

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

                return Ok(_MaquinaVirtualRepository.ListarMinhas(id));
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
                MaquinaVirtual MaquinaVirtualBuscado = _MaquinaVirtualRepository.Listarid(id);

                return Ok(_MaquinaVirtualRepository.ListarUma(id));
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