using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZavrsniTest.Models;
using ZavrsniTest.Repository.Interface;

namespace ZavrsniTest.Repository
{
    // RibaRepository: Manages data access for the Riba entity using Entity Framework Core.
    public class RibaRepository : IRibaRepository
    {
        private readonly AppDbContext _context; // DbContext for database operations

        // Constructor: Initializes the repository with the application's database context.
        public RibaRepository(AppDbContext context)
        {
            this._context = context;
        }

        // Add a new Riba entity to the database.
        public void Add(Riba riba)
        {
            _context.Ribe.Add(riba); // Adds the new Riba to the DbSet
            _context.SaveChanges();  // Commits the change to the database
        }

        // Delete a Riba entity from the database.
        public void Delete(Riba riba)
        {
            _context.Ribe.Remove(riba); // Removes the Riba from the DbSet
            _context.SaveChanges();     // Commits the change to the database
        }

        // Retrieve all Riba entities, including their associated Ribarnica entities.
        public IQueryable<Riba> GetAll()
        {
            return _context.Ribe.Include(c => c.Ribarnica); // Uses eager loading to include Ribarnica details
        }

        // Retrieve a specific Riba entity by its ID, including its associated Ribarnica entity.
        public Riba GetById(int id)
        {
            return _context.Ribe.Include(c => c.Ribarnica).FirstOrDefault(p => p.Id == id); // Uses eager loading
        }

        // Search for Riba entities based on quantity range and order by price descending.
        public IQueryable<Riba> Pretraga(int najmanje, int najvise)
        {
            return _context.Ribe
                .Include(c => c.Ribarnica)
                .Where(x => x.Kolicina >= najmanje && x.Kolicina <= najvise)
                .OrderByDescending(p => p.Cena); // Orders the results by price in descending order
        }

        // Update an existing Riba entity in the database.
        public void Update(Riba riba)
        {
            _context.Entry(riba).State = EntityState.Modified; // Marks the Riba as modified

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
