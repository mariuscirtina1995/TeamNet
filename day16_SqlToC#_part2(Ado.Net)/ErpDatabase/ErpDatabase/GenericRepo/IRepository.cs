﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpDatabase.GenericRepo
{
    public interface IRepository<T>
        where T: IEntity, new()
    {
        int Insert(T entity);

        void Update(T entity);

        void Delete(T entity);

        T GetById(int id);

        IList<T> GetAll();
    }
}
