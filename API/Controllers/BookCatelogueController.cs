using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MediatR;
using BookCatalogue.Application.BookRegistration.Commands;
using BookCatalogue.Application.BookRegistration.Query;
using BookCatalogue.Application.Models.Contracts.Requests;
using BookCatalogue.Application.Command;
using BookCatalogue.Application.Dto;
using BookCatalogue.Application.Enums;

namespace BookCatalogue.API.Controllers
{
    [ApiController]
    [Route("api/bookcatelogue")]
    public class BookCatelogueController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public BookCatelogueController(IMediator mediator, IMapper mapper)
        {           
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookCatalogueDto>>> GetBookCatelogues([FromQuery] SearchCatalogueQuery searchCriteria)
        {
            var getSearchCatalogueQuery = mapper.Map<GetSearchCatalogueQuery>(searchCriteria);
            var response = await mediator.Send(getSearchCatalogueQuery);

            if (response.Status == Status.NotFound)
                return NotFound();

            return Ok(response.bookCatalogues);
        }


        [HttpGet("{Id}")]
        public async Task<ActionResult<BookCatalogueDto>> GetBookCatelogue(Guid Id)
        {
            var getSearchCatalogueQuery = mapper.Map<GetSearchCatalogueQuery>(Id);
            var response = await mediator.Send(getSearchCatalogueQuery);

            if (response.Status == Status.NotFound || !response.bookCatalogues.Any())
                return NotFound();

            return Ok(response.bookCatalogues);
        }

        [HttpPost]
        public async Task<ActionResult<BookCatalogueDto>> CreateBookCatalogue(CreateBookCatalogueCommand createBookCatalogueRequest)
        {
            var response = await mediator.Send(createBookCatalogueRequest);

            if (response.Status == Status.NotFound)
                return NotFound();

            return Ok(response.bookCatalogue);
        }


        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateBookCatalogue(Guid Id,
           UpdateBookCatalogueRequest updateBookCatalogueRequest)
        {
            var updateBookCatalogueCommand = mapper.Map<UpdateBookCatalogueCommand>(updateBookCatalogueRequest);
            updateBookCatalogueCommand.Id = Id;

            var response = await mediator.Send(updateBookCatalogueCommand);
            if (response.Status == Status.NotFound)
                return NotFound();

            return NoContent();
        }


        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteBookCatelogue(Guid Id)
        {
            var deleteBookCatalogueCommand = mapper.Map<DeleteBookCatalogueCommand>(Id);
            var response = await mediator.Send(deleteBookCatalogueCommand);

            if (response.Status==Status.Success)
                return NoContent();
          
            return NotFound();
        }
    }
}
