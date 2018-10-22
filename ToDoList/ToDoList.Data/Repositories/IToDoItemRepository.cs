using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Data.Entities;

namespace ToDoList.Data.Repositories
{
    public interface IToDoItemRepository : IBaseRepository<ToDoItem>
    {
    }
}
