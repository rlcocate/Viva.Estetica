using System.ComponentModel;

namespace Viva.Estetica.Dominio
{
    public class Servico
    {
        public int Id { get; set; }

        [DisplayName("Serviço")]
        public string Nome { get; set; }        
    }
}
