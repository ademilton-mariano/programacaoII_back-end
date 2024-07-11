using System.ComponentModel.DataAnnotations;

namespace programacaoII_back_end.Aplication.ViewModels;

public class LoginViewModel
{
    [Required(ErrorMessage = "O e-mail é obrigatório")
     , EmailAddress(ErrorMessage = "O e-mail informado não é valido")
     , MaxLength(50, ErrorMessage = "O e-mail informado é muito grande")
     , MinLength(5, ErrorMessage = "O e-mail informado é muito pequeno")
    ]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "A senha é obrigatória")
     , MaxLength(50, ErrorMessage = "A senha informada é muito grande")
     , MinLength(8, ErrorMessage = "A senha informada é muito pequena")
    ]
    public string Senha { get; set; }
}