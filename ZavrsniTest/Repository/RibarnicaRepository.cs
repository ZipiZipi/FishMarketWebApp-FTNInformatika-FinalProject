using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZavrsniTest.Models;
using ZavrsniTest.Repository.Interface;

namespace ZavrsniTest.Repository
{
    // RibarnicaRepository: Manages data access for the Ribarnica entity using Entity Framework Core.
    public class RibarnicaRepository : IRibarnicaRepository
    {
        private readonly AppDbContext _context; // DbContext for database operations

        // Constructor: Initializes the repository with the application's database context.
        public RibarnicaRepository(AppDbContext context)
        {
            this._context = context;
        }

        // Add a new Ribarnica entity to the database.
        public void Add(Ribarnica ribarnica)
        {
            _context.Ribarnice.Add(ribarnica); // Adds the new Ribarnica to the DbSet
            _context.SaveChanges();            // Commits the change to the database
        }

        // Delete a Ribarnica entity from the database.
        public void Delete(Ribarnica ribarnica)
        {
            _context.Ribarnice.Remove(ribarnica); // Removes the Ribarnica from the DbSet
            _context.SaveChanges();               // Commits the change to the database
        }

        // Retrieve all Ribarnica entities from the database.
        public IQueryable<Ribarnica> GetAll()
        {
            return _context.Ribarnice; // Returns all Ribarnica entries
        }

        // Retrieve a specific Ribarnica entity by its ID.
        public Ribarnica GetById(int id)
        {
            return _context.Ribarnice.FirstOrDefault(p => p.Id == id); // Retrieves a Ribarnica by its ID
        }

        // Find Ribarnica entities by their name, ordered by year of opening and then by name.
        public IQueryable<Ribarnica> PronadjiPoNazivu(string vrednost)
        {
            return _context.Ribarnice
                .Where(c => c.Naziv.Contains(vrednost))
                .OrderBy(p => p.GodinaOtvaranja)
                .ThenBy(z => z.Naziv); // Orders results first by year of opening, then by name
        }

        // Update an existing Ribarnica entity in the database.
        public void Update(Ribarnica ribarnica)
        {
            _context.Entry(ribarnica).State = EntityState.Modified; // Marks the Ribarnica as modified

            try
            {
                _context.SaveChanges(); // Attempts to save changes to the database
            }
            catch (DbUpdateConcurrencyException)
            {
                throw; // Rethrows the exception to be handled by the caller
            }
        }
    }
}
