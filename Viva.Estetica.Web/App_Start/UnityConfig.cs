using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using Viva.Estetica.Dominio;
using Viva.Estetica.InfraEstrutura;

namespace Viva.Estetica.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            UnityContainer container = new UnityContainer();

            container.RegisterType<IAplicacao<Cliente>, ClienteAplicacao>();
            container.RegisterType<IAplicacao<Agenda>, AgendaAplicacao>();
            container.RegisterType<IAgendamento, AgendaAplicacao>();

            container.RegisterType<IRepositorio<Cliente>, ClienteRepositorio>();
            container.RegisterType<IRepositorio<Agenda>, AgendaRepositorio>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}