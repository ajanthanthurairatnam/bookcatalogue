using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BookCatalogue.Application.BookRegistration.Query;
using BookCatalogue.Application.Dto;
using BookCatalogue.Application.Enums;
using BookCatalogue.Tests.Database;

namespace BookCatalogue.Tests.Persistence
{
    public class GetSearchCatalogueQueryData : IEnumerable<object[]>
    {

        public GetSearchCatalogueQueryData()
        {

        }
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
                        {
                            new SearchCatalogueResponse()
                            {
                              Status = Status.Success,
                              bookCatalogues = DbContextSetup.Books.Where(e=>e.Title=="Sample One")
                                                        .Select(d=>new BookCatalogueDto()
                                                                        {
                                                                                Authors =   d.Authors.Select(a=>new AuthorDto(){ AuthorName = a.AuthorName,Id=a.Id }).ToList(),
                                                                                Id = d.Id,
                                                                                ISBN =d.ISBN,
                                                                                PublicationDate =d.PublicationDate,
                                                                                Title =d.Title
                                                                        })
                            },
                            new GetSearchCatalogueQuery() { Title ="Sample One" }
                        };

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }


}
