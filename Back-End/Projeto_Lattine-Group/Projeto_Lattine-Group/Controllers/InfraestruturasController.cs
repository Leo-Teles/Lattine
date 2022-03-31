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
    public class InfraestruturasController : ControllerBase
    {
        private IInfraestruturaRepository _InfraestruturaRepository { get; set; }

        public InfraestruturasController()
        {
            _InfraestruturaRepository = new InfraestruturaRepository();
        }

        /// <summary>
        /// Lista todos os Infraestruturas
        /// </summary>
        /// <returns>Uma lista de Infraestruturas com um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            List<Infraestrutura> listaInfraestruturas = _InfraestruturaRepository.Listar();
            return Ok(listaInfraestruturas);
        }

        /// <summary>
        /// Busca um Infraestrutura através de seu ID
        /// </summary>
        /// <param name="id">ID do Infraestrutura buscado</param>
        /// <returns>O Infraestrutura buscado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Infraestrutura InfraestruturaBuscado = _InfraestruturaRepository.Listarid(id);

            if (InfraestruturaBuscado == null)
            {
                return NotFound("Nenhum Infraestrutura encontrado.");
            }

            return Ok(InfraestruturaBuscado);
        }

        /// <summary>
        /// Cadastra um novo Infraestrutura
        /// </summary>
        /// <param name="novoInfraestrutura">Objeto novoInfraestrutura com os novos dados</param>
        [HttpPost]
        public IActionResult Post(Infraestrutura novoInfraestrutura)
        {
            _InfraestruturaRepository.Cadastrar(novoInfraestrutura);

            return StatusCode(201);
        }

        /// <summary>
        /// Deleta um Infraestrutura existente
        /// </summary>
        /// <param name="id">ID do Infraestrutura deletado</param>
        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _InfraestruturaRepository.Deletar(id);
            return StatusCode(204);
        }

        /// <summary>
        /// Atualiza um Infraestrutura existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="id">id do Infraestrutura que será atualizado</param>
        /// <param name="InfraestruturaAtualizado">Objeto InfraestruturaAtualizado com os novos dados</param>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Infraestrutura InfraestruturaAtualizado)
        {
            Infraestrutura InfraestruturaBuscado = _InfraestruturaRepository.Listarid(id);

            if (InfraestruturaBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Infraestrutura não encontrado.",
                        erro = true
                    });
            }

            try
            {
                _InfraestruturaRepository.Atualizar(id, InfraestruturaAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}