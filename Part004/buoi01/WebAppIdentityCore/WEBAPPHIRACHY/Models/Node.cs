﻿namespace WebApp.Models
{
    public class Node
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }

        public int Value { get; set; }

        public List<string> LinkWith { get; set; }

        public string Phone { get; set; }
    }
}
