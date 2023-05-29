namespace WebApplication1.Models
{
    public class User
    {
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? NomeUsuario { get; set; }
        
        private int user;

        public int GetUser()
        {
            return user;
        }

        internal void SetUser(int value)
        {
            user = value;
        }
    }
}
