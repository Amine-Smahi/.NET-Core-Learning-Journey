using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MeklaAPI.Entities;
using MeklaAPI.Helpers;
using MeklaAPI.MeklaCRUD;
using MeklaAPI.Models;
using MeklaAPI.Repositories;

namespace MeklaAPI.v1.Controllers {
    [ApiVersion ("1.0")]
    [Route ("api/v{version:apiVersion}/[controller]")]
    //[Route("api/[controller]")]
    [ApiController]
    public class MeklasController : ControllerBase {
        private readonly IMeklaRepository _MeklaRepository;
        private readonly IUrlHelper _urlHelper;

        public MeklasController (IUrlHelper urlHelper, IMeklaRepository MeklaRepository) {
            _MeklaRepository = MeklaRepository;
            _urlHelper = urlHelper;
        }

        [HttpGet (Name = nameof (GetAllMeklas))]
        public ActionResult GetAllMeklas ([FromQuery] QueryParameters queryParameters) {
            var allItemCount = _MeklaRepository.Count();

            var paginationMetadata = new {
                totalCount = allItemCount,
                pageSize = queryParameters.PageCount,
                currentPage = queryParameters.Page,
                totalPages = queryParameters.GetTotalPages (allItemCount)
            };

            Response.Headers.Add ("X-Pagination",
                Newtonsoft.Json.JsonConvert.SerializeObject (paginationMetadata));

            var links = CreateLinksForCollection (queryParameters, allItemCount);

            List<Mekla> Meklas = _MeklaRepository.GetAll(queryParameters).ToList();
            var toReturn = Meklas.Select(x => ExpandSingleMekla(x));

            return Ok (new {
                value = toReturn,
                    links = links
            });
        }

        [HttpGet]
        [Route ("{id:int}", Name = nameof (GetSingleMekla))]
        public ActionResult GetSingleMekla (int id) {
            Mekla Mekla = _MeklaRepository.GetSingle (id);

            if (Mekla == null) {
                return NotFound ();
            }

            return Ok (ExpandSingleMekla (Mekla));
        }

        [HttpPost (Name = nameof (AddMekla))]
        public ActionResult<Mekla> AddMekla ([FromBody] MeklaCreate meklaCreate) {
            if (meklaCreate == null) {
                return BadRequest ();
            }

            if (!ModelState.IsValid) {
                return BadRequest (ModelState);
            }

            Mekla toAdd = Mapper.Map<Mekla> (meklaCreate);

            _MeklaRepository.Add (toAdd);

            if (!_MeklaRepository.Save ()) {
                throw new Exception ("Creating a Mekla failed on save.");
            }

            Mekla newMekla = _MeklaRepository.GetSingle (toAdd.Id);

            return CreatedAtRoute (nameof (GetSingleMekla), new { id = newMekla.Id },
                Mapper.Map<Mekla> (newMekla));
        }

        [HttpPatch ("{id:int}", Name = nameof (PartiallyUpdateMekla))]
        public ActionResult<Mekla> PartiallyUpdateMekla (int id, [FromBody] JsonPatchDocument<MeklaUpdate> patchDoc) {
            if (patchDoc == null) {
                return BadRequest ();
            }

            Mekla existingEntity = _MeklaRepository.GetSingle (id);

            if (existingEntity == null) {
                return NotFound ();
            }

            MeklaUpdate MeklaUpdate = Mapper.Map<MeklaUpdate> (existingEntity);
            patchDoc.ApplyTo (MeklaUpdate, ModelState);

            TryValidateModel (MeklaUpdate);

            if (!ModelState.IsValid) {
                return BadRequest (ModelState);
            }

            Mapper.Map (MeklaUpdate, existingEntity);
            Mekla updated = _MeklaRepository.Update (id, existingEntity);

            if (!_MeklaRepository.Save ()) {
                throw new Exception ("Updating a Mekla failed on save.");
            }

            return Ok (Mapper.Map<Mekla> (updated));
        }

        [HttpDelete]
        [Route ("{id:int}", Name = nameof (RemoveMekla))]
        public ActionResult RemoveMekla (int id) {
            Mekla Mekla = _MeklaRepository.GetSingle (id);

            if (Mekla == null) {
                return NotFound ();
            }

            _MeklaRepository.Delete (id);

            if (!_MeklaRepository.Save ()) {
                throw new Exception ("Deleting a Mekla failed on save.");
            }

            return NoContent ();
        }

        [HttpPut]
        [Route ("{id:int}", Name = nameof (UpdateMekla))]
        public ActionResult<Mekla> UpdateMekla (int id, [FromBody] MeklaUpdate MeklaUpdate) {
            if (MeklaUpdate == null) {
                return BadRequest ();
            }

            var existingMekla = _MeklaRepository.GetSingle (id);

            if (existingMekla == null) {
                return NotFound ();
            }

            if (!ModelState.IsValid) {
                return BadRequest (ModelState);
            }

            Mapper.Map (MeklaUpdate, existingMekla);

            _MeklaRepository.Update (id, existingMekla);

            if (!_MeklaRepository.Save ()) {
                throw new Exception ("Updating a Mekla failed on save.");
            }

            return Ok (Mapper.Map<Mekla> (existingMekla));
        }

        [HttpGet ("GetRandomMeal", Name = nameof (GetRandomMeal))]
        public ActionResult GetRandomMeal () {
            ICollection<Mekla> Meklas = _MeklaRepository.GetRandomMeal ();

            IEnumerable<Mekla> s = Meklas
                .Select (x => Mapper.Map<Mekla> (x));

            var links = new List<Link> ();

            // self 
            links.Add (new Link (_urlHelper.Link (nameof (GetRandomMeal), null), "self", "GET"));

            return Ok (new {
                value = s,
                    links = links
            });
        }

        private List<Link> CreateLinksForCollection (QueryParameters queryParameters, int totalCount) {
            var links = new List<Link> ();

            // self 
            links.Add (
                new Link (_urlHelper.Link (nameof (GetAllMeklas), new {
                    pagecount = queryParameters.PageCount,
                        page = queryParameters.Page,
                        orderby = queryParameters.OrderBy
                }), "self", "GET"));

            links.Add (new Link (_urlHelper.Link (nameof (GetAllMeklas), new {
                pagecount = queryParameters.PageCount,
                    page = 1,
                    orderby = queryParameters.OrderBy
            }), "first", "GET"));

            links.Add (new Link (_urlHelper.Link (nameof (GetAllMeklas), new {
                pagecount = queryParameters.PageCount,
                    page = queryParameters.GetTotalPages (totalCount),
                    orderby = queryParameters.OrderBy
            }), "last", "GET"));

            if (queryParameters.HasNext (totalCount)) {
                links.Add (new Link (_urlHelper.Link (nameof (GetAllMeklas), new {
                    pagecount = queryParameters.PageCount,
                        page = queryParameters.Page + 1,
                        orderby = queryParameters.OrderBy
                }), "next", "GET"));
            }

            if (queryParameters.HasPrevious ()) {
                links.Add (new Link (_urlHelper.Link (nameof (GetAllMeklas), new {
                    pagecount = queryParameters.PageCount,
                        page = queryParameters.Page - 1,
                        orderby = queryParameters.OrderBy
                }), "previous", "GET"));
            }

            links.Add (
                new Link (_urlHelper.Link (nameof (AddMekla), null),
                    "create_Mekla",
                    "POST"));

            return links;
        }

        private dynamic ExpandSingleMekla (Mekla Mekla) {
            var links = GetLinks (Mekla.Id);
            Mekla item = Mapper.Map<Mekla> (Mekla);

            var resourceToReturn = item.ToDynamic () as IDictionary<string, object>;
            resourceToReturn.Add ("links", links);

            return resourceToReturn;
        }

        private IEnumerable<Link> GetLinks (int id) {
            var links = new List<Link> ();

            links.Add (
                new Link (_urlHelper.Link (nameof (GetSingleMekla), new { id = id }),
                    "self",
                    "GET"));

            links.Add (
                new Link (_urlHelper.Link (nameof (RemoveMekla), new { id = id }),
                    "delete_Mekla",
                    "DELETE"));

            links.Add (
                new Link (_urlHelper.Link (nameof (AddMekla), null),
                    "create_Mekla",
                    "POST"));

            links.Add (
                new Link (_urlHelper.Link (nameof (UpdateMekla), new { id = id }),
                    "update_Mekla",
                    "PUT"));

            return links;
        }
    }
}