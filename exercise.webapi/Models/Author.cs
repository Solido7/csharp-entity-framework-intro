﻿using System.Text.Json.Serialization;

namespace exercise.webapi.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();

        public AuthorDto ToDto()
        {
            return new AuthorDto
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Books = Books.Select(b => b.ToPublisherDto()).ToList()
            };
        }

        public AuthorData ToData()
        {
            return new AuthorData
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email
            };
        }
    }
    public struct AuthorDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<BookPublisherDto> Books { get; set; }
    }

    public struct AuthorData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    } 

    public struct AuthorParams
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
