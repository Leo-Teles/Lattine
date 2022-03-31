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
    public class GrupoRecursosController : ControllerBase
    {
        private IGrupoRecursoRepository _GrupoRecursoRepository { get; set; }

        public GrupoRecursosController()
        {
            _GrupoRecursoRepository = new GrupoRecursoRepository();
        }

        /// <summary>
        /// Lista todos os GrupoRecursos
        /// </summary>
        /// <returns>Uma lista de GrupoRecursos com um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            List<GrupoRecurso> listaGrupoRecursos = _GrupoRecursoRepository.Listar();
            return Ok(listaGrupoRecursos);
        }

        /// <summary>
        /// Busca um GrupoRecurso através de seu ID
        /// </summary>
        /// <param name="id">ID do GrupoRecurso buscado</param>
        /// <returns>O GrupoRecurso buscado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GrupoRecurso GrupoRecursoBuscado = _GrupoRecursoRepository.Listarid(id);

            if (GrupoRecursoBuscado == null)
            {
                return NotFound("Nenhum GrupoRecurso encontrado.");
            }

            return Ok(GrupoRecursoBuscado);
        }

        /// <summary>
        /// Cadastra um novo GrupoRecurso
        /// </summary>
        /// <param name="novoGrupoRecurso">Objeto novoGrupoRecurso com os novos dados</param>
        [HttpPost]
        public IActionResult Post(GrupoRecurso novoGrupoRecurso)
        {
            _GrupoRecursoRepository.Cadastrar(novoGrupoRecurso);

            return StatusCode(201);
        }

        /// <summary>
        /// Deleta um GrupoRecurso existente
        /// </summary>
        /// <param name="id">ID do GrupoRecurso deletado</param>
        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _GrupoRecursoRepository.Deletar(id);
            return StatusCode(204);
        }

        /// <summary>
        /// Atualiza um GrupoRecurso existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="id">id do GrupoRecurso que será atualizado</param>
        /// <param name="GrupoRecursoAtualizado">Objeto GrupoRecursoAtualizado com os novos dados</param>
        [HttpPut("{id}")]
        public IActionResult Put(int id, GrupoRecurso GrupoRecursoAtualizado)
        {
            GrupoRecurso GrupoRecursoBuscado = _GrupoRecursoRepository.Listarid(id);

            if (GrupoRecursoBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "GrupoRecurso não encontrado.",
                        erro = true
                    });
            }

            try
            {
                _GrupoRecursoRepository.Atualizar(id, GrupoRecursoAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}