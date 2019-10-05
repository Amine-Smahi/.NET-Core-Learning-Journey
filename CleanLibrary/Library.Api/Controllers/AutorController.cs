using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Domain.Entities;
using Library.Domain.Interfaces;
using Library.Service.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Autor")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IServiceBase<Autor> _autorService;

        public AutorController(IServiceBase<Autor> autorService)
        {
            _autorService = autorService;
        }

        [HttpPost]
        [Route("inserir")]
        public IActionResult Post([FromBody] Autor autor)
        {
            try
            {
                _autorService.Post<AutorValidator>(autor);
                return new ObjectResult(autor.Id);
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
        public IActionResult Put([FromBody] Autor autor)
        {
            try
            {
                _autorService.Put<AutorValidator>(autor);
                return new ObjectResult(autor);
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
                _autorService.Delete(id);
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
                return new ObjectResult(_autorService.GetAll());
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
                return new ObjectResult(_autorService.GetById(id));
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