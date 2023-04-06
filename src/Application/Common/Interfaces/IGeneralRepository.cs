using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractMng.Application.Common.Interfaces;
public interface IGeneralRepository<T> 
{
    Task<int> Create(T item);
    Task<int> Update(T item);
    Task Delete(int id);
    Task<T> Get(int id);
    Task<IEnumerable<T>> GetAll();

}

