using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContractMng.Application.Common.Interfaces;
using IdentityModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ContractMng.Infrastructure.Repositories;
public abstract class GeneralRepository<TEntity> : IGeneralRepository<TEntity> where TEntity : class
{
    private readonly IApplicationDbContext _context;
    private readonly DbSet<TEntity> _entity;

    public GeneralRepository(IApplicationDbContext context)
    {
        _context = context;
        _entity= _context.Set<TEntity>();    
    }
    public async Task<int> Create(TEntity item)
    {
        var result= await _entity.AddAsync(item);
        return result.d;
         
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> Get(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TEntity>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<int> Update(TEntity item)
    {
        throw new NotImplementedException();
    }
}
