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
    public class GrupoInfraestruturasController : ControllerBase
    {
        private IGrupoInfraestruturaRepository _GrupoInfraestruturaRepository { get; set; }

        public GrupoInfraestruturasController()
        {
            _GrupoInfraestruturaRepository = new GrupoInfraestruturaRepository();
        }

        /// <summary>
        /// Lista todos os GrupoInfraestruturas
        /// </summary>
        /// <returns>Uma lista de GrupoInfraestruturas com um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            List<GrupoInfraestrutura> listaGrupoInfraestruturas = _GrupoInfraestruturaRepository.Listar();
            return Ok(listaGrupoInfraestruturas);
        }

        /// <summary>
        /// Busca um GrupoInfraestrutura através de seu ID
        /// </summary>
        /// <param name="id">ID do GrupoInfraestrutura buscado</param>
        /// <returns>O GrupoInfraestrutura buscado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GrupoInfraestrutura GrupoInfraestruturaBuscado = _GrupoInfraestruturaRepository.Listarid(id);

            if (GrupoInfraestruturaBuscado == null)
            {
                return NotFound("Nenhum GrupoInfraestrutura encontrado.");
            }

            return Ok(GrupoInfraestruturaBuscado);
        }

        /// <summary>
        /// Cadastra um novo GrupoInfraestrutura
        /// </summary>
        /// <param name="novoGrupoInfraestrutura">Objeto novoGrupoInfraestrutura com os novos dados</param>
        [HttpPost]
        public IActionResult Post(GrupoInfraestrutura novoGrupoInfraestrutura)
        {
            _GrupoInfraestruturaRepository.Cadastrar(novoGrupoInfraestrutura);

            return StatusCode(201);
        }

        /// <summary>
        /// Deleta um GrupoInfraestrutura existente
        /// </summary>
        /// <param name="id">ID do GrupoInfraestrutura deletado</param>
        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _GrupoInfraestruturaRepository.Deletar(id);
            return StatusCode(204);
        }

        /// <summary>
        /// Atualiza um GrupoInfraestrutura existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="id">id do GrupoInfraestrutura que será atualizado</param>
        /// <param name="GrupoInfraestruturaAtualizado">Objeto GrupoInfraestruturaAtualizado com os novos dados</param>
        [HttpPut("{id}")]
        public IActionResult Put(int id, GrupoInfraestrutura GrupoInfraestruturaAtualizado)
        {
            GrupoInfraestrutura GrupoInfraestruturaBuscado = _GrupoInfraestruturaRepository.Listarid(id);

            if (GrupoInfraestruturaBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "GrupoInfraestrutura não encontrado.",
                        erro = true
                    });
            }

            try
            {
                _GrupoInfraestruturaRepository.Atualizar(id, GrupoInfraestruturaAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}