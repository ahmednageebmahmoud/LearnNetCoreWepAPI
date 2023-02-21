﻿using System.ComponentModel.DataAnnotations;

namespace LearnNetCoreWepAPI.models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> Age { get; set; }
    }
}
