using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        // 使用者清單 lista de usuários
        private List<User> usuarios = new List<User>();
        // 最新使用者ID ID de usuário mais recente
        private int lastId = 1;

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return usuarios;
        }

        // 新增使用者 adicionar usuário
        [HttpPost]
        public IActionResult Post(User user)
        {
            if (usuarios.Any(u => u.NomeUsuario == user.NomeUsuario))
            {
                return BadRequest("nome de usuário já utilizado");
            }
            else
            {
                usuarios.Add(user);
                return Ok(user);
            }
        }

        [HttpDelete("{nomeUsuario}")]
        public IActionResult Delete(string nomeUsuario)
        {
            var user = usuarios.FirstOrDefault(u => u.NomeUsuario == nomeUsuario);
            if (user != null)
            {
                usuarios.Remove(user);
                return Ok($" utilizador {nomeUsuario}  excluído com sucesso。");
            }
            else
            {
                return NotFound($"do utilizador {nomeUsuario} não existe。");
            }
        }

        [HttpPut("{nomeUsuario}")]
        public IActionResult Put(string nomeUsuario, User updatedUser)
        {
            var user = usuarios.FirstOrDefault(u => u.NomeUsuario == nomeUsuario);
            if (user != null)
            {
                if (usuarios.Any(u => u.NomeUsuario == updatedUser.NomeUsuario && u != user))
                {
                    return BadRequest("nome de usuário já utilizado");
                }
                else
                {
                    user.Nome = updatedUser.Nome;
                    user.Sobrenome = updatedUser.Sobrenome;
                    user.Email = updatedUser.Email;
                    user.Senha = updatedUser.Senha;
                    user.NomeUsuario = updatedUser.NomeUsuario;
                    return Ok(user);
                }
            }
            else
            {
                return NotFound($"do utilizador {nomeUsuario} não existe。");
            }
        }
    }
}
