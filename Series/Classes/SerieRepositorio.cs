using System;
using System.Collections.Generic;
using Series.Interfaces;

namespace Series.Classes
{
    public class SerieRepositorio : IRepositorio<Series>
    {
       private List<Series> listaSerie = new List<Series>();
        public void Atualizar(int id, Series objeto)
        {
            listaSerie[id] = objeto;
        }

        public void Excluir(int id)
        {
            listaSerie[id].Excluir();           
        }

        public void Insere(Series objeto)
        {
            listaSerie.Add(objeto);
        }

        public List<Series> List()
        {
            return listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }

        public Series RetornaPorId(int id)
        {
            return listaSerie[id];
        }
    }
}