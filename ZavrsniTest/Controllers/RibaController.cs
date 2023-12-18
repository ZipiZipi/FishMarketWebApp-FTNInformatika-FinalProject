using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZavrsniTest.Models;
using ZavrsniTest.Models.DTO;
using ZavrsniTest.Repository.Interface;

namespace ZavrsniTest.Controllers
{
    // The RibaController is responsible for handling API requests related to 'Riba' entities.
    // It includes endpoints for CRUD operations and a custom search.
    [Route("api/ribe")]
    [ApiController]
    [Authorize]
    public class RibaController : ControllerBase
    {
        private readonly IRibaRepository _ribaRepository;
        private readonly IMapper _mapper;
        // Constructor initializes the controller with necessary dependencies
        public RibaController(IRibaRepository ribaRepository, IMapper mapper)
        {
            _ribaRepository = ribaRepository;
            _mapper = mapper;
        }
        // Retrieves all 'Riba' entries from the repository.
        // This endpoint does not require authorization.
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetRibe()
        {
            return Ok(_ribaRepository.GetAll().ProjectTo<RibaDTO>(_mapper.ConfigurationProvider).ToList());
        }
        // Retrieves a specific 'Riba' entry by its ID.
        // Requires authorization.
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetRiba(int id)
        {
            var riba = _ribaRepository.GetById(id);

            if (riba == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<RibaDTO>(riba));
        }
        // Updates a specific 'Riba' entry identified by its ID.
        // Requires authorization.
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult PutRiba(int id, Riba riba)
        {
            if (id != riba.Id)
            {
                return BadRequest();
            }

            try
            {
                _ribaRepository.Update(riba);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(riba);
        }
        // Creates a new 'Riba' entry.
        // Requires authorization.
        [Authorize]
        [HttpPost]
        public IActionResult PostRiba(Riba riba)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _ribaRepository.Add(riba);
            return CreatedAtAction("GetRiba", new { id = riba.Id }, riba);
        }
        // Deletes a specific 'Riba' entry by its ID.
        // Requires authorization.
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteRiba(int id)
        {
            var riba = _ribaRepository.GetById(id);
            if (riba == null)
            {
                return NotFound();
            }

            _ribaRepository.Delete(riba);
            return NoContent();
        }
        // Custom search endpoint to filter 'Riba' entries based on a range.
        // Requires authorization.
        [Authorize]
        [Route("/api/pretraga")]
        [HttpPost]
        public IActionResult Pretraga(int najmanje, int najvise)
        {
            return Ok(_ribaRepository.Pretraga(najmanje,najvise).ProjectTo<RibaDTO>(_mapper.ConfigurationProvider).ToList());
        }
    }
}
