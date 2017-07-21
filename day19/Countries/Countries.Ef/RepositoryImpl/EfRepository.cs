﻿using Countries.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Countries.Ef.RepositoryImpl
{
    public class EfRepository<T> : IRepository<T>
    where T : class, IEntity, new()
    {
        private DbContext context;

        public EfRepository(DbContext context)
        {
            this.context = context;
        }

        public void Delete(string id)
        {
            var entity = GetById(id);

            if (entity != null)
            {
                context.Set<T>().Remove(entity);
            }

            context.SaveChanges();
        }

        public IList<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public T GetById(string id)
        {
            return context.Set<T>().SingleOrDefault(a => a.Code == id);
        }

        public string Insert(T entity)
        {
            context.Set<T>().Add(entity);

            context.SaveChanges();

            return entity.Code;
        }

        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;

            context.SaveChanges();
        }
    }
}
