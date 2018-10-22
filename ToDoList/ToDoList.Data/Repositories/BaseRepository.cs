using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Data.Context;
using ToDoList.Data.Entities;

namespace ToDoList.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity, new()
    {
        protected DbContext Context { get; set; }
        protected DbSet<T> DbSet { get; set; }

        public BaseRepository(ToDoListContext dbContext)
        {
            Context = dbContext;
            DbSet = Context.Set<T>();
        }

        public void Delete(T item)
        {
            Context.Entry(item).State = EntityState.Deleted;
            Context.SaveChanges();
        }

        public void Edit(T item)
        {
            DbSet.Update(item);
            Context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return DbSet;
        }

        public T GetById(int id)
        {
            return DbSet.Find(id);
        }

        public void Insert(T item)
        {
            Context.Add(item);
            Context.SaveChanges();
        }
    }
}
