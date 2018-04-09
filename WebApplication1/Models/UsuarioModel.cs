using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;

namespace WebApplication1.Models
{
    public class UsuarioModel
    {
        public int ID { get; set; }

        [Display(Name = "Usuário")]
        [Required]
        [StringLength(200)]
        public string UserName { get; set; }

        [Display(Name = "Nome Completo")]
        public string Nome { get; set; }


        

        private string senha { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "A senha é obrigatória")]
        [StringLength(255, ErrorMessage = "A senha deve ter pelo menos 5 caracteres", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Senha
        {
            get
            {
                return senha;
            }
            set
            {
                byte[] data = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(value));
                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                senha = sBuilder.ToString();
            }
        }

        [Display(Name = "CPF")]
        public string CPF { get; set; }

        [Display(Name = "Aniversário")]
        [DataType(DataType.Date)]
        public DateTime Aniversario { get; set; }
    }
}
