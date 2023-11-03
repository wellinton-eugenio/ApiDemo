﻿using primeiroProjeto.Enums;

namespace primeiroProjeto.Models
{
    public class ToDoModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public StatusToDo Status {  get; set; }
    }
}