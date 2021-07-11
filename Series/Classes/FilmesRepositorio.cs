using Series.Interfaces;
using System.Collections.Generic;

namespace Series.Classes
{
    class FilmesRepositorio : IRepositorio<Filmes>
    {
        private List<Filmes> listaFilme = new List<Filmes>();
        public void Atualizar(int id, Filmes objeto)
        {
            listaFilme[id] = objeto;
        }

        public void Excluir(int id)
        {
            listaFilme[id].Excluir();
        }

        public void Insere(Filmes objeto)
        {
            listaFilme.Add(objeto);
        }

        public List<Filmes> List()
        {
            return listaFilme;
        }

        public int ProximoId()
        {
            return listaFilme.Count;
        }

        public Filmes RetornaPorId(int id)
        {
            return listaFilme[id];
        }
    }
}
