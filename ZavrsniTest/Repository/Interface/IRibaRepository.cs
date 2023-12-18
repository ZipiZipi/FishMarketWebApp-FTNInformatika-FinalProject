using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZavrsniTest.Models;

namespace ZavrsniTest.Repository.Interface
{
    // Interface for the Riba repository.
    // Defines the standard operations to be implemented by the Riba repository.
    public interface IRibaRepository
    {
        // Retrieves all Riba entities as a queryable collection.
        IQueryable<Riba> GetAll();

        // Retrieves a specific Riba entity by its unique identifier.
        Riba GetById(int id);

        // Adds a new Riba entity to the repository.
        void Add(Riba riba);

        // Updates an existing Riba entity in the repository.
        void Update(Riba riba);

        // Deletes a Riba entity from the repository.
        void Delete(Riba riba);

        // Performs a search on Riba entities based on a quantity range.
        // Returns a queryable collection of Riba entities matching the criteria.
        IQueryable<Riba> Pretraga(int najmanje, int najvise);
    }
}
