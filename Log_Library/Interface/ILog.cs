using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log_Library
{
    public interface ILog<T> 
    {
        List<T> SelectAll();

        T SelectById(string Id);

        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
