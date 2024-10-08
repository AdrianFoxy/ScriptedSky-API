﻿using System.Text.Json.Serialization;
using Core.Entities.Base;

namespace Core.Entities
{
    public class Author : BaseEntity
    {
        public required string Name { get; set; }
        public required string EnName { get; set; }
        [JsonIgnore]
        public List<BookAuthor>? BookAuthor { get; set; }
        [JsonIgnore]
        public List<Book>? Book { get; set; }

    }
}
