﻿namespace CompileCrew.Models.Base
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool SoftDelete { get; set; }
    }
}