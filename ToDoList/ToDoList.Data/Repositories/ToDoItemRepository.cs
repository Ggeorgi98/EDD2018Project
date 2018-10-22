using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Data.Context;
using ToDoList.Data.Entities;

namespace ToDoList.Data.Repositories
{
    public class ToDoItemRepository : BaseRepository<ToDoItem>, IToDoItemRepository
    {
        public ToDoItemRepository(ToDoListContext dbContext) : base(dbContext)
        {
        }
    }
}
