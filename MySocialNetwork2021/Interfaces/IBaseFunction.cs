using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySocialNetwork2021.Interfaces
{
    public interface IBaseFunction<T>
    {
        IEnumerable<T> GetList();
        void Create(T item);
        T Get(int id);
        void Update(T item);
        void Delete(int id);
    }
}
