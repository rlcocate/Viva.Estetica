using System;
using System.ComponentModel.DataAnnotations;
using Viva.Estetica.Dominio.Enums;

namespace Viva.Estetica.Dominio
{
    public class Agenda
    {
        public int Id { get; set; }

        public TipoServico TipoServico { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required]
        public string Data { get; set; }
        
        [Display(Name = "Horário")]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        [Required]
        public string Horario { get; set; }

        [Display(Name = "Duração")]
        [Required]
        public int Duracao { get; set; }

        public Cliente Cliente { get; set; }
        
        public Servico Servico { get; set; }
        
        [Display(Name = "Sessão")]
        public int IdSessoes { get; set; }

        public Agenda()
        {
            Cliente = new Cliente();
            Servico = new Servico();
        }
    }
}
