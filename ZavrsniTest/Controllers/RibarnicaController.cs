using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZavrsniTest.Models;
using ZavrsniTest.Repository.Interface;

namespace ZavrsniTest.Controllers
{
    // The RibarnicaController manages API requests related to the 'Ribarnica' entity.
    // It provides endpoints for CRUD operations and a custom search by name.
    [Authorize]
    [Route("api/ribarnice")]
    [ApiController]
    public class RibarnicaController : ControllerBase
    {
        private readonly IRibarnicaRepository _ribarnicaRepository;
        // Constructor: Initializes the controller with the required repository.

        public RibarnicaController(IRibarnicaRepository ribarnicaRepository)
        {
            _ribarnicaRepository = ribarnicaRepository;
        }
        // Retrieves all Ribarnica entries.
        // This endpoint is accessible without authorization.
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetRibarnice()
        {
            return Ok(_ribarnicaRepository.GetAll().ToList());
        }
        // Retrieves a specific Ribarnica entry by its ID.
        // Requires authorization.
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetRibarnica(int id)
        {
            var ribarnica = _ribarnicaRepository.GetById(id);

            if (ribarnica == null)
            {
                return NotFound();
            }

            return Ok(ribarnica);
        }
        // Updates a specific Ribarnica entry identified by its ID.
        // Requires authorization.
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult PutRibarnica(int id, Ribarnica ribarnica)
        {
            if (id != ribarnica.Id)
            {
                return BadRequest();
            }

            try
            {
                _ribarnicaRepository.Update(ribarnica);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(ribarnica);
        }
        // Creates a new Ribarnica entry.
        // Requires authorization.
        [Authorize]
        [HttpPost]
        public IActionResult PostRibarnica(Ribarnica ribarnica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _ribarnicaRepository.Add(ribarnica);
            return CreatedAtAction("GetRibarnica", new { id = ribarnica.Id }, ribarnica);
        }
        // Deletes a specific Ribarnica entry by its ID.
        // Requires authorization.
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteCountry(int id)
        {
            var ribarnica = _ribarnicaRepository.GetById(id);
            if (ribarnica == null)
            {
                return NotFound();
            }

            _ribarnicaRepository.Delete(ribarnica);
            return NoContent();
        }
        // Finds Ribarnica entries by their name.
        // Requires authorization.
        [Authorize]
        [Route("nadji/naziv={vrednost}")]
        [HttpGet]
        public IActionResult PronadjiPoNazivu(string vrednost)
        {
            return Ok(_ribarnicaRepository.PronadjiPoNazivu(vrednost).ToList());
        }
        // The Info endpoint (currently commented out) retrieves a specific Ribarnica entry by ID.

        /*[Route("info")]
        [HttpGet()]
        public IActionResult Info(int vrednost)
        {
            var riba = _ribarnicaRepository.GetById(vrednost);

            if (riba == null)
            {
                return NotFound();
            }

            return Ok(riba);
        }*/
    }
}
