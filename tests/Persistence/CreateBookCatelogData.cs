using System;
using System.Collections;
using System.Collections.Generic;
using BookCatalogue.Application.Command;
using BookCatalogue.Application.Dto;
using BookCatalogue.Application.Enums;

namespace BookCatalogue.Tests.Persistence
{
    public class CreateBookCatelogData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
                        {
                            Status.Success,
                            new CreateBookCatalogueCommand() {
                                Title = "Fundamentals of C#", ISBN = "444445555666", PublicationDate = DateTime.UtcNow,
                                Authors = new List<AuthorCreateRequest>
                                {
                                    new AuthorCreateRequest() { AuthorName ="Eddie" }
                                }
                            }
                        };
            yield return new object[]
                       {
                            Status.Success,
                            new CreateBookCatalogueCommand() {
                                Title = "Fundamentals of F#", ISBN = "12345678343", PublicationDate = DateTime.UtcNow,
                                Authors = new List<AuthorCreateRequest>
                                {
                                    new AuthorCreateRequest() { AuthorName ="Some one" }
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
