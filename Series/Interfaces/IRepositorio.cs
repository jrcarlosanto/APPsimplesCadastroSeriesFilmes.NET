using System.Collections.Generic;

namespace Series.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> List();
        T RetornaPorId(int id);
        void Insere(T entidadde);
        void Excluir(int id);
        void Atualizar(int id, T entidade);
        int ProximoId(); 
    }
}