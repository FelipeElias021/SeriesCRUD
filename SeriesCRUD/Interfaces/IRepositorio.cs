using System;
using System.Collections.Generic;
using System.Text;

namespace SeriesCRUD.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> GetAll();
        T GetByID(int id);
        void Add(T objeto);
        void Delete(int id);
        void Update(int id, T objeto);
        int NextId();
    }
}
