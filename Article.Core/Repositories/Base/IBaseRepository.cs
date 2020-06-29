using Article.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Article.Core.Repositories.Base
{
    public interface IBaseRepository<T> where T : class, IEntityBase, new()
    {
        List<T> GetAll();
        T Get(int id);
        void Add(T entity);
        bool Update(T entity);
        void Delete(T entity);
    }
}
