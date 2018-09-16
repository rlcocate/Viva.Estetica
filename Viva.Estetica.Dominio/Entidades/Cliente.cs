using System.ComponentModel.DataAnnotations;

namespace Viva.Estetica.Dominio
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe um nome válido")]
        public string Nome { get; set; }
                
        public string Sobrenome { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe um documento válido")]
        public string Documento { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe um celular válido")]
        public string Celular { get; set; }

        public string Endereco { get; set; }
    }
}
