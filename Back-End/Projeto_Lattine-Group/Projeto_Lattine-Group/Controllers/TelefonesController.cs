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
    public class TelefonesController : ControllerBase
    {
        private ITelefoneRepository _TelefoneRepository { get; set; }

        public TelefonesController()
        {
            _TelefoneRepository = new TelefoneRepository();
        }

        /// <summary>
        /// Lista todos os Telefones
        /// </summary>
        /// <returns>Uma lista de Telefones com um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            List<Telefone> listaTelefones = _TelefoneRepository.Listar();
            return Ok(listaTelefones);
        }

        /// <summary>
        /// Busca um Telefone através de seu ID
        /// </summary>
        /// <param name="id">ID do Telefone buscado</param>
        /// <returns>O Telefone buscado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Telefone TelefoneBuscado = _TelefoneRepository.Listarid(id);

            if (TelefoneBuscado == null)
            {
                return NotFound("Nenhum Telefone encontrado.");
            }

            return Ok(TelefoneBuscado);
        }

        /// <summary>
        /// Cadastra um novo Telefone
        /// </summary>
        /// <param name="novoTelefone">Objeto novoTelefone com os novos dados</param>
        [HttpPost]
        public IActionResult Post(Telefone novoTelefone)
        {
            _TelefoneRepository.Cadastrar(novoTelefone);

            return StatusCode(201);
        }

        /// <summary>
        /// Deleta um Telefone existente
        /// </summary>
        /// <param name="id">ID do Telefone deletado</param>
        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _TelefoneRepository.Deletar(id);
            return StatusCode(204);
        }

        /// <summary>
        /// Atualiza um Telefone existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="id">id do Telefone que será atualizado</param>
        /// <param name="TelefoneAtualizado">Objeto TelefoneAtualizado com os novos dados</param>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Telefone TelefoneAtualizado)
        {
            Telefone TelefoneBuscado = _TelefoneRepository.Listarid(id);

            if (TelefoneBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Telefone não encontrado.",
                        erro = true
                    });
            }

            try
            {
                _TelefoneRepository.Atualizar(id, TelefoneAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}