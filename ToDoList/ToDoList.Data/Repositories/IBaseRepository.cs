using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Data.Entities;

namespace ToDoList.Data.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity, new()
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Insert(T item);
        void Edit(T item);
        void Delete(T item);
    }
}
