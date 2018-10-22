using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Data.Entities;
using ToDoList.Data.Repositories;

namespace ToDoList.Service
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity, new()
    {
        public IBaseRepository<T> baseRepository;

        public BaseService(IBaseRepository<T> baseRepository)
        {
            this.baseRepository = baseRepository;
        }

        public void Delete(T item)
        {
            baseRepository.Delete(item);
        }

        public void Edit(T item)
        {
            baseRepository.Edit(item);
        }

        public IEnumerable<T> GetAll()
        {
            return baseRepository.GetAll();
        }

        public T GetById(int id)
        {
            return baseRepository.GetById(id);
        }

        public void Insert(T item)
        {
            baseRepository.Insert(item);
        }
    }
}
