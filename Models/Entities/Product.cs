﻿namespace Models.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; } // Nullable without using `?`

        public string Author { get; set; }

        public double Price { get; set; }
    }
}
