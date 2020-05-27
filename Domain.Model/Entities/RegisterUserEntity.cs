using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Model
{
    public class RegisterUserEntity
    {
        [Key]
        public int UserId { get; set; }

        [StringLength(20, MinimumLength = 3)]
        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public string UserName { get; set; }

        [StringLength(20, MinimumLength = 3)]
        [Required(ErrorMessage = "Este campo é obrigatório")]

        public string UserSurname { get; set; }

        [Required]
        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")] 
        public string Email {get; set;}

        [Required]
        [StringLength(100, ErrorMessage = "O {0} deve ter pelo menos {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "A senha e a senha de confirmação não coincidem.")]
        public string ConfirmPassword { get; set; }


    }
}
