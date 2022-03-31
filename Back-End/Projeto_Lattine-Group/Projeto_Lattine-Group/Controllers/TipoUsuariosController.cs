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
    public class TipoUsuariosController : ControllerBase
    {
        private ITipoUsuarioRepository _TipoUsuarioRepository { get; set; }

        public TipoUsuariosController()
        {
            _TipoUsuarioRepository = new TipoUsuarioRepository();
        }

        /// <summary>
        /// Lista todos os TipoUsuarios
        /// </summary>
        /// <returns>Uma lista de TipoUsuarios com um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            List<TipoUsuario> listaTipoUsuarios = _TipoUsuarioRepository.Listar();
            return Ok(listaTipoUsuarios);
        }

        /// <summary>
        /// Busca um TipoUsuario através de seu ID
        /// </summary>
        /// <param name="id">ID do TipoUsuario buscado</param>
        /// <returns>O TipoUsuario buscado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            TipoUsuario TipoUsuarioBuscado = _TipoUsuarioRepository.Listarid(id);

            if (TipoUsuarioBuscado == null)
            {
                return NotFound("Nenhum TipoUsuario encontrado.");
            }

            return Ok(TipoUsuarioBuscado);
        }

        /// <summary>
        /// Cadastra um novo TipoUsuario
        /// </summary>
        /// <param name="novoTipoUsuario">Objeto novoTipoUsuario com os novos dados</param>
        [HttpPost]
        public IActionResult Post(TipoUsuario novoTipoUsuario)
        {
            _TipoUsuarioRepository.Cadastrar(novoTipoUsuario);

            return StatusCode(201);
        }

        /// <summary>
        /// Deleta um TipoUsuario existente
        /// </summary>
        /// <param name="id">ID do TipoUsuario deletado</param>
        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _TipoUsuarioRepository.Deletar(id);
            return StatusCode(204);
        }

        /// <summary>
        /// Atualiza um TipoUsuario existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="id">id do TipoUsuario que será atualizado</param>
        /// <param name="TipoUsuarioAtualizado">Objeto TipoUsuarioAtualizado com os novos dados</param>
        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoUsuario TipoUsuarioAtualizado)
        {
            TipoUsuario TipoUsuarioBuscado = _TipoUsuarioRepository.Listarid(id);

            if (TipoUsuarioBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "TipoUsuario não encontrado.",
                        erro = true
                    });
            }

            try
            {
                _TipoUsuarioRepository.Atualizar(id, TipoUsuarioAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}