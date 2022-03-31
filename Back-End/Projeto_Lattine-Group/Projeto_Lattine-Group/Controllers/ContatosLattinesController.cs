using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projeto_Lattine_Group.Domains;
using Projeto_Lattine_Group.Interfaces;
using Projeto_Lattine_Group.Repositories;
using System;
using System.Collections.Generic;

namespace Projeto_Lattine_Group.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ContatosLattinesController : ControllerBase
    {
        private IContatosLattineRepository _ContatosLattineRepository { get; set; }

        public ContatosLattinesController()
        {
            _ContatosLattineRepository = new ContatosLattineRepository();
        }

        /// <summary>
        /// Lista todos os ContatosLattines
        /// </summary>
        /// <returns>Uma lista de ContatosLattines com um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            List<ContatosLattine> listaContatosLattines = _ContatosLattineRepository.Listar();
            return Ok(listaContatosLattines);
        }

        /// <summary>
        /// Busca um ContatosLattine através de seu ID
        /// </summary>
        /// <param name="id">ID do ContatosLattine buscado</param>
        /// <returns>O ContatosLattine buscado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            ContatosLattine ContatosLattineBuscado = _ContatosLattineRepository.Listarid(id);

            if (ContatosLattineBuscado == null)
            {
                return NotFound("Nenhum ContatosLattine encontrado.");
            }

            return Ok(ContatosLattineBuscado);
        }

        /// <summary>
        /// Cadastra um novo ContatosLattine
        /// </summary>
        /// <param name="novoContatosLattine">Objeto novoContatosLattine com os novos dados</param>
        [HttpPost]
        public IActionResult Post(ContatosLattine novoContatosLattine)
        {
            _ContatosLattineRepository.Cadastrar(novoContatosLattine);

            return StatusCode(201);
        }

        /// <summary>
        /// Deleta um ContatosLattine existente
        /// </summary>
        /// <param name="id">ID do ContatosLattine deletado</param>
        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _ContatosLattineRepository.Deletar(id);
            return StatusCode(204);
        }

        /// <summary>
        /// Atualiza um ContatosLattine existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="id">id do ContatosLattine que será atualizado</param>
        /// <param name="ContatosLattineAtualizado">Objeto ContatosLattineAtualizado com os novos dados</param>
        [HttpPut("{id}")]
        public IActionResult Put(int id, ContatosLattine ContatosLattineAtualizado)
        {
            ContatosLattine ContatosLattineBuscado = _ContatosLattineRepository.Listarid(id);

            if (ContatosLattineBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "ContatosLattine não encontrado.",
                        erro = true
                    });
            }

            try
            {
                _ContatosLattineRepository.Atualizar(id, ContatosLattineAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}