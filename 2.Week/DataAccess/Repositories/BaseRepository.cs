using DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public void Add(T entity)
        {
            using (Context context = new Context())
            {
                context.Add(entity);
                context.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (Context context = new Context())
            {
                T deletedItem = context.Set<T>().Find(id);
                var deletedEntity = context.Entry(deletedItem);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public List<T> GetAll()
        {
            using (Context context = new Context())
            {
                return context.Set<T>().ToList();
            }
        }
        public T GetById(int id)
        {
            using (Context context = new Context())
            {

                return context.Set<T>().Find(id);
            }
        }
        public void Update(T entity)
        {
            using (Context context = new Context())
            {
                context.Update(entity);
                context.SaveChanges();
            }
        }
    }
}
