using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.Services
{
    public interface IDataService<T>
    {
        Task<T> Get(T entity);

        Task<T> Create(T entity);
    }
}
