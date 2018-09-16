using System.Collections.Generic;

namespace Viva.Estetica.InfraEstrutura
{
    public interface IAplicacao<T> where T : class
    {
        IEnumerable<T> Obter();

        T Obter(int id);

        IEnumerable<T> Inserir(T entidade);

        IEnumerable<T> Atualizar(T entidade);

        IEnumerable<T> Excluir(int id);
    }
}
