using System;
using System.Collections.Generic;
using System.Linq;
using API_Desafio_Angular.Context;
using API_Desafio_Angular.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_Desafio_Angular.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T>   where T : class
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public void Inserir(T obj)
        {
            _dbContext.Entry(obj).State = EntityState.Added;
            _dbContext.SaveChanges();
        }

        public void Alterar(T obj)
        {
            _dbContext.Entry(obj).State = EntityState.Modified;
            _dbContext.SaveChanges();
            
        }
        
        public void Excluir(T obj)
        {
            _dbContext.Entry(obj).State = EntityState.Deleted;
            _dbContext.SaveChanges();
        }
        public List<T> Consultar()
        {          
            return _dbContext.Set<T>().ToList();
        }

        public T ObterPorId(Guid id)
        {
           var entity = _dbContext.Set<T>().Find(id);
           _dbContext.Entry(entity).State = EntityState.Detached;
           return entity;
        }
    }
}