using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Data.Entities;
using ToDoList.Web.Models;

namespace ToDoList.Web.AutoMapperProfile
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ToDoItem, ToDoModel>();
            CreateMap<ToDoModel, ToDoItem>();
        }
    }
}
