using System.ComponentModel.DataAnnotations;

namespace Viva.Estetica.Dominio
{
    public class Telefone
    {
        public int DDI { get; set; }

        public int DDD { get; set; }

        public string Numero { get; set; }

        [Required]
        public string Formatado
        {
            get { return ($"+{ DDI.ToString("00") }-{ DDI.ToString("00") }-{ Numero }"); }
        }
    }
}
