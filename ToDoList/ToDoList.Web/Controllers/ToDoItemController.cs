using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Data.Entities;
using ToDoList.Service;
using ToDoList.Web.Models;

namespace ToDoList.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/ToDoItem")]
    public class ToDoItemController : ControllerBase
    {
        private readonly IToDoItemService toDoItemService;
        private readonly IMapper mapper;

        public ToDoItemController(IToDoItemService toDoItemService, IMapper mapper)
        {
            this.toDoItemService = toDoItemService;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var list = toDoItemService.GetAll().ToList();
            List<ToDoModel> models = mapper.Map<List<ToDoModel>>(list);

            return Ok(models);
        }

        [HttpGet("{id}", Name = "GetTodoitem")]
        public ActionResult GetById(int id)
        {
            var item = toDoItemService.GetById(id);
            if (item == null)
                return NotFound();
            else
            {
                var model = mapper.Map<ToDoModel>(item);

                return Ok(model);
            }
        }

        [HttpPost]
        public ActionResult Create([FromBody]ToDoModel model)
        {
            var item = mapper.Map<ToDoItem>(model);
            toDoItemService.Insert(item);

            var entity = mapper.Map<ToDoModel>(item);

            return CreatedAtRoute("GetTodo", new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody]ToDoModel model, int id)
        {
            var item = toDoItemService.GetById(id);
            if (item == null)
                return NotFound();

            //item.Name = model.Name;
            //item.Description = model.Description;
            //item.CreationDate = model.CreationDate;
            item = mapper.Map<ToDoItem>(model);
            item.Id = id;
            toDoItemService.Edit(item);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var item = toDoItemService.GetById(id);
            if (item == null)
                return NotFound();

            toDoItemService.Delete(item);

            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult Update(int id, [FromBody]JsonPatchDocument<ToDoModel> model)
        {
            var item = toDoItemService.GetById(id);
            if (item == null)
                return NotFound();           

            var itemToPatch = mapper.Map<ToDoModel>(item);

            model.ApplyTo(itemToPatch, ModelState);
            mapper.Map(itemToPatch, item);

            toDoItemService.Edit(item);

            return NoContent();
        }
    }
}