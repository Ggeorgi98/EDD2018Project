using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Data.Entities;

namespace ToDoList.Data.Context
{
    public class ToDoListContext : DbContext
    {
        public ToDoListContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<ToDoItem> ToDoItems { get; set; }
    }
}
