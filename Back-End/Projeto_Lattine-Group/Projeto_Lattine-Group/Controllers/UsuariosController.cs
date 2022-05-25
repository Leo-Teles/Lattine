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
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _UsuarioRepository { get; set; }

        public UsuariosController()
        {
            _UsuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Lista todos os Usuarios
        /// </summary>
        /// <returns>Uma lista de Usuarios com um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            List<Usuario> listaUsuarios = _UsuarioRepository.Listar();
            return Ok(listaUsuarios);
        }

        /// <summary>
        /// Busca um Usuario através de seu ID
        /// </summary>
        /// <param name="id">ID do Usuario buscado</param>
        /// <returns>O Usuario buscado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Usuario UsuarioBuscado = _UsuarioRepository.Listarid(id);

            if (UsuarioBuscado == null)
            {
                return NotFound("Nenhum Usuario encontrado.");
            }

            return Ok(UsuarioBuscado);
        }

        /// <summary>
        /// Cadastra um novo Usuario
        /// </summary>
        /// <param name="novoUsuario">Objeto novoUsuario com os novos dados</param>
        [HttpPost]
        public IActionResult Post(Usuario novoUsuario)
        {
            _UsuarioRepository.Cadastrar(novoUsuario);

            return StatusCode(201);
        }

        /// <summary>
        /// Deleta um Usuario existente
        /// </summary>
        /// <param name="id">ID do Usuario deletado</param>
        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _UsuarioRepository.Deletar(id);
            return StatusCode(204);
        }

        /// <summary>
        /// Atualiza um Usuario existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="id">id do Usuario que será atualizado</param>
        /// <param name="UsuarioAtualizado">Objeto UsuarioAtualizado com os novos dados</param>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Usuario UsuarioAtualizado)
        {
            Usuario UsuarioBuscado = _UsuarioRepository.Listarid(id);

            if (UsuarioBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Usuario não encontrado.",
                        erro = true
                    });
            }

            try
            {
                _UsuarioRepository.Atualizar(id, UsuarioAtualizado);

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

                return Ok(_UsuarioRepository.ListarMeus(id));
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
                Usuario UsuarioBuscado = _UsuarioRepository.Listarid(id);

                return Ok(_UsuarioRepository.ListarUm(id));
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