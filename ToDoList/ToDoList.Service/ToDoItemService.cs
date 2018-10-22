using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Data.Entities;
using ToDoList.Data.Repositories;

namespace ToDoList.Service
{
    public class ToDoItemService : BaseService<ToDoItem>, IToDoItemService
    {
        public ToDoItemService(IToDoItemRepository toDoItemRepository)
            : base(toDoItemRepository)
        {

        }
    }
}
