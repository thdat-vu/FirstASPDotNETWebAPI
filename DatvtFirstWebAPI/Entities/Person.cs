﻿namespace DatvtFirstWebAPI.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Place { get; set; }
    }
}
