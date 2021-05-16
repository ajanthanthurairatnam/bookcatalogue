using System;
using System.Linq;
using AutoMapper;
using BookCatalogue.Application.BookRegistration.Commands;
using BookCatalogue.Application.BookRegistration.Query;
using BookCatalogue.Application.Models.Contracts.Requests;
using BookCatalogue.Application.Command;
using BookCatalogue.Application.Dto;
using BookCatalogue.Domain.Entities;


namespace BookCatalogue.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Author, AuthorDto>();
            CreateMap<AuthorDto, Author>();
            CreateMap<AuthorCreateRequest, Author>();
            CreateMap<CreateBookCatalogueCommand, Book>()
                 .ForMember(dest => dest.Authors, src => src.MapFrom(src => src.Authors));

            CreateMap<UpdateBookCatalogueRequest, Book>()
                 .ForMember(dest => dest.Authors, src => src.MapFrom(src => src.Authors));
            //CreateMap<UpdateBookCatalogueRequest, Book>()
            //    .ForMember(dest => dest.Authors, src => src.MapFrom(src => src.Authors.Select(x=> new Author() { AuthorName = x.AuthorName, Id= x.Id })));
            CreateMap<Book, BookCatalogueDto>();
            CreateMap<Book, BookCatalogueResponse>().ForMember(dest => dest.bookCatalogue, src => src.MapFrom(e=>e));
            CreateMap<SearchCatalogueQuery, GetSearchCatalogueQuery>();
            CreateMap<Guid, GetSearchCatalogueQuery>().ForMember(dest => dest.Id, src => src.MapFrom(e => e));
            CreateMap<UpdateBookCatalogueRequest, UpdateBookCatalogueCommand>();
            CreateMap<UpdateBookCatalogueCommand, UpdateBookCatalogueRequest>();
            CreateMap<Guid, DeleteBookCatalogueCommand>().ForMember(dest => dest.Id, src => src.MapFrom(e => e));

        }
    }
}
