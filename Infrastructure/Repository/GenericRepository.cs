using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public readonly DataContext _context;
        private DbSet<T> table;
        public GenericRepository(DataContext context)
        {
            _context = context;
            table = _context.Set<T>();
            
        }

        public void delete(object id)
        {
            T entity = GetById(id);
            table.Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(object id)
        {
                return table.Find(id);
        }

        public void insert(T entity)
        {
            table.Add(entity);
        }

        public void update(T entity)
        {
            table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
