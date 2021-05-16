using System;
using System.Collections;
using System.Collections.Generic;
using BookCatalogue.Application.BookRegistration.Commands;
using BookCatalogue.Application.Dto;
using BookCatalogue.Application.Enums;
using BookCatalogue.Tests.Database;

namespace BookCatalogue.Tests.Persistence
{
    public class UpdateBookCatelogData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
                        {
                            Status.Success,
                            new UpdateBookCatalogueCommand() {
                                Id = DbContextSetup.BookIdSample2Id,
                                Title = "Azure fundamentals",
                                ISBN = "999888009888",
                                PublicationDate = DateTime.UtcNow,
                                Authors = new List<AuthorDto>
                                {
                                    new AuthorDto() { AuthorName ="John" },
                                    new AuthorDto() { AuthorName ="Lowanna" }
                                }
                            }
                        };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
