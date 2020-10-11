using mysocietywebsite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace mysocietywebsite.Resource.interfaces
{
    public interface IRespository
    {
        public interface IRepository<T> where T : BaseEntity
        {
            IEnumerable<T> GetAll();
            T Get(Guid id);
            void Insert(T entity);
            void Update(T entity);
            void Delete(T entity);
            void Save();
        }
    }
}
