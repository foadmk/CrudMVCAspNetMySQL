using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Services;

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



        [StringLength(255, ErrorMessage = "A senha deve ter pelo menos 5 caracteres", MinimumLength = 5)]
        [Display(Name = "Senha")]
        [Required(ErrorMessage = "A senha é obrigatória")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        public void HashPassword()
        {
            Senha = HashCalculator.GenerateMD5(Senha);            
        }

        [Display(Name = "CPF")]
        public string CPF { get; set; }

        [Display(Name = "Aniversário")]
        [DataType(DataType.Date)]
        public DateTime Aniversario { get; set; }
    }
}
