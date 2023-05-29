using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        // 使用者清單
        private User[] usuarios = Array.Empty<User>();
        // 最新使用者ID
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


        // 新增使用者
        [HttpPost]
        public string Post(User user)
        {
            // User novoUsuario = user;

            // 檢查陣列中是否有相同的使用者名稱

            // 如果有, 回傳使用者名稱已被使用


            // 反之, 新增到使用者清單, 將最新使用者ID + 1 並回傳已新增使用者
            // usuarios = usuarios.Append(novoUsuario).ToArray();
            return "ok";

        }

        [HttpDelete]
        public string Delete(int id)
        {
            // 檢查陣列中是否存在使用者ID
            // 如果有, 將使用者刪除並回傳使用者已被刪除

            // 反之回傳使用者不存在
            return "Usuário não encontrado";
        }

        [HttpPut]
        public string Put(int id)
        {
            // 檢查陣列中是否存在使用者ID
            // 如果有, 更新使用者並回傳使用者已被更新

            // 反之回傳使用者不存在
            return "Usuário não encontrado";
        }
    }
}