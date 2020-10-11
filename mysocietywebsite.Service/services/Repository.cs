using Microsoft.EntityFrameworkCore;
using mysocietywebsite.Model.ApplicationDbContext;
using mysocietywebsite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static mysocietywebsite.Resource.interfaces.IRespository;

namespace mysocietywebsite.Service.services
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
            private readonly AppDbContext context;
            private DbSet<T> entities;
            //string errorMessage = string.Empty;
            public Repository(AppDbContext context)
            {
                this.context = context;
                entities = context.Set<T>();
            }
            public IEnumerable<T> GetAll()
            {
                return entities.AsEnumerable();
            }
            public void Insert(T entity)
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                entities.Add(entity);
            }
            public void Update(T entity)
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
            }
            public void Delete(T entity)
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                entities.Remove(entity);
            }

            public void Save()
            {
                context.SaveChanges();
            }

            public T Get(Guid id)
            {
                return entities.SingleOrDefault(s => s.Id == id);
            }
            public IEnumerable<T> FromSqlQuery(string query, params object[] args) {
                return entities.FromSqlRaw(query, args);
            } 
    }
}
