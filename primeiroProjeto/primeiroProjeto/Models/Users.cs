﻿namespace primeiroProjeto.Models
{
    public class UsersModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public static implicit operator List<object>(UsersModel v)
        {
            throw new NotImplementedException();
        }
    }
}
