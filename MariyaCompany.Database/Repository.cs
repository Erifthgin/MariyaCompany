using Microsoft.EntityFrameworkCore;
using MariyaCompany.Database.Contexts;
using MariyaCompany.Application.Abstractions.Database;
using System.Linq;

namespace MariyaCompany.Database
{
    internal class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet;
        private readonly MariyaCompanyContext _context;

        public Repository(MariyaCompanyContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public bool Create(T item)
        {
            _dbSet.Add(item);
            return _context.SaveChanges() == 1;
        }

        public T FindById(int id)
        {
            return _dbSet.Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsNoTracking();
        }

        public IQueryable<T> GetAllWithVirtual()
        {
            return IncludeAll(_dbSet.AsNoTracking());
        }

        public IQueryable<T> GetAllWithSelectVirtual(string property)
        {
            return Include(_dbSet.AsNoTracking(), property);
        }

        public bool Remove(T item)
        {
            _dbSet.Remove(item);
            return _context.SaveChanges() == 1;
        }

        public bool Update(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
           return _context.SaveChanges() == 1;
        }

        private IQueryable<T> IncludeAll<T>(IQueryable<T> queryable) where T : class
        {
            var type = typeof(T);
            var properties = type.GetProperties();
            foreach (var property in properties)
            {
                var isVirtual = property.GetGetMethod().IsVirtual;
                if (isVirtual)
                {
                    queryable = queryable.Include(property.Name);
                }
            }
            return queryable;
        }

        private IQueryable<T> Include<T>(IQueryable<T> queryable, string propertyName) where T : class
        {
            var type = typeof(T);
            var properties = type.GetProperties();

            if (properties.Any())
            {
                var property = properties.Where(p => p.Name == propertyName).FirstOrDefault();

                if (property != null)
                {
                    var isVirtual = property.GetGetMethod().IsVirtual;
                    if (isVirtual)
                    {
                        queryable = queryable.Include(property.Name);
                    }
                }
            }
            return queryable;
        }
    }
}
