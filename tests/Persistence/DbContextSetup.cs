using System;
using System.Collections.Generic;
using BookCatalogue.Domain.Entities;

namespace BookCatalogue.Tests.Database
{
    public static class DbContextSetup
    {
        public static Guid BookIdSample1Id { get; set; } = Guid.Parse("da88f3e4-0fb7-48da-8c4c-4403df4d0ef3");

        public static List<Author> AuthorsBook1 = new List<Author>()
                                {
                                    new Author() { AuthorName = "AJANTHAN", Id = Guid.NewGuid() },
                                    new Author() { AuthorName = "Kajotha", Id = Guid.NewGuid() }
                                };
        public static Guid BookIdSample2Id { get; set; } = Guid.Parse("afd39f21-c335-499e-bdf4-b7aa194f1126");

        public static List<Author> AuthorsBook2 = new List<Author>()
                                {
                                    new Author() { AuthorName = "Steve", Id = Guid.NewGuid() }
                                };
        public static Guid BookIdSample3Id { get; set; } = Guid.Parse("ac852424-f6ea-4c29-bd1f-b8fb3b45c21f");

        public static List<Author> AuthorsBook3 = new List<Author>()
                                {
                                    new Author() { AuthorName = "Mark", Id = Guid.NewGuid() }
                                };

        public static List<Book> Books { get; set; } = SetupBooks();
        private static List<Book> SetupBooks()
        {
            List<Book> Books = new List<Book>();
            Books.Add(
                        new Book()
                        {
                            Id = BookIdSample1Id,
                            ISBN = "1234567890123",                           
                            Title = "Sample One",
                            PublicationDate = DateTime.UtcNow,
                            Authors = AuthorsBook1
                        });
            Books.Add(
                      new Book()
                      {
                          Id = BookIdSample2Id,
                          ISBN = "0456667778992",
                          Title = "Second Book",
                          PublicationDate = DateTime.UtcNow,
                          Authors = AuthorsBook2
                      });
            Books.Add(
                    new Book()
                    {
                        Id = BookIdSample3Id,
                        ISBN = "9993334443332",
                        Title = "Thrid Book",
                        PublicationDate = DateTime.UtcNow,
                        Authors = AuthorsBook3
                    });


            return Books;
        }

      

    }
}
