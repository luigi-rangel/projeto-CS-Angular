using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProEventos.Application.DTOs
{
    public class EventoDTO
    {
        public int Id {get; set;}
        public string Local {get; set;}
        public string DataEvento {get; set;}

        [Required(ErrorMessage = "O campo {0} é obrigatório"),
        StringLength(50, MinimumLength = 3, ErrorMessage = "Intervalo permitido de 3 a 50 caracteres.")]
        public string Tema {get; set;}

        [Display(Name = "Qtd Pessoas"),
        Range(1, 120000, ErrorMessage = "{0} não pode ser menor que 1 nem maior que 120000.")]
        public int QtdPessoas {get; set;}

        [RegularExpression(@".*\.(gif|jpe?g|bmp|png)$", ErrorMessage = "Não e uma imagem válida ")]
        public string ImageURL {get; set;}

        [Required(ErrorMessage = "O campo {0} é obrigatório"),
        Phone(ErrorMessage = "O campo {0} está com número inválido")]
        public string Telefone { get; set; }

        [Display(Name = "e-mail"),
        Required(ErrorMessage = "O campo {0} é obrigatório"),
        EmailAddress(ErrorMessage = "O campo {0} precisa ser um e-mail válido")]
        public string Email { get; set; }

        public IEnumerable<LoteDTO> Lotes { get; set; }
        public IEnumerable<RedeSocialDTO> RedesSociais { get; set; }
        public IEnumerable<EventoDTO> Eventos { get; set; }
    }
}