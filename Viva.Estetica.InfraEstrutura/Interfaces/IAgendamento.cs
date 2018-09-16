using System;
using Viva.Estetica.Dominio.Enums;

namespace Viva.Estetica.InfraEstrutura
{
    public interface IAgendamento
    {
        bool ValidarHorarioMarcarAgendamento();

        string ValidarPeriodoCancelamentoRemarcacaoAgendamento(int id);
    }
}
