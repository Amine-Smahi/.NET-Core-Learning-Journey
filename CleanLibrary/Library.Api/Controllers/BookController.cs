using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Domain.Entities;
using Library.Domain.Interfaces;
using Library.Service.Services;
using Library.Service.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IServiceBase<Book> _BookService;

        public BookController(IServiceBase<Book> BookService)
        {
            _BookService = BookService;
        }

        [HttpPost]
        [Route("inserir")]
        public IActionResult Post([FromBody] Book Book)
        {
            try
            {
                _BookService.Post<BookValidator>(Book);
                return new ObjectResult(Book.Id);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        [Route("alterar")]
        public IActionResult Put([FromBody] Book Book)
        {
            try
            {
                _BookService.Put<BookValidator>(Book);
                return new ObjectResult(Book);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        [Route("remover/{id:int}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _BookService.Delete(id);
                return new NoContentResult();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("listar")]
        public IActionResult GetAll()
        {
            try
            {
                return new ObjectResult(_BookService.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("obter/{id:int}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return new ObjectResult(_BookService.GetById(id));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}