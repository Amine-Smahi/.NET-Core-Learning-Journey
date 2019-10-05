using System;
using Library.Domain.Entities;
using Library.Domain.Interfaces;
using Library.Service.Validators;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Editor")]
    [ApiController]
    public class EditorController : ControllerBase
    {
        private readonly IServiceBase<Editor> _EditorService;

        public EditorController(IServiceBase<Editor> EditorService)
        {
            _EditorService = EditorService;
        }

        [HttpPost]
        [Route("inserir")]
        public IActionResult Post([FromBody] Editor Editor)
        {
            try
            {
                _EditorService.Post<EditorValidator>(Editor);
                return new ObjectResult(Editor.Id);
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
        public IActionResult Put([FromBody] Editor Editor)
        {
            try
            {
                _EditorService.Put<EditorValidator>(Editor);
                return new ObjectResult(Editor);
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
                _EditorService.Delete(id);
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
                return new ObjectResult(_EditorService.GetAll());
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
                return new ObjectResult(_EditorService.GetById(id));
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