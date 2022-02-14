using System;
using System.Collections.Generic;
using System.Text;
using SeriesCRUD.Interfaces;

namespace SeriesCRUD.Classes
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> series = new List<Serie>();

        public void Add(Serie objeto)
        {
            series.Add(objeto);
        }

        public void Delete(int id)
        {
            series[id].Excluir();
        }

        public Serie GetByID(int id)
        {
            return series[id];
        }

        public List<Serie> GetAll()
        {
            return series;
        }

        public int NextId()
        {
            return series.Count;
        }

        public void Update(int id, Serie objeto)
        {
            series[id] = objeto;
        }
    }
}
