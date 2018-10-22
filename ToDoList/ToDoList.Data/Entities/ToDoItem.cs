using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList.Data.Entities
{
    public class ToDoItem : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }        
    }
}
