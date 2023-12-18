using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZavrsniTest.Models;

namespace ZavrsniTest.Repository.Interface
{
    // Defines the necessary operations for managing the Ribarnica data.
    public interface IRibarnicaRepository
    {
        // Retrieves all Ribarnica entities as a queryable collection.
        IQueryable<Ribarnica> GetAll();

        // Retrieves a specific Ribarnica entity by its unique identifier (id).
        Ribarnica GetById(int id);

        // Adds a new Ribarnica entity to the repository.
        void Add(Ribarnica ribarnica);

        // Updates an existing Ribarnica entity in the repository.
        void Update(Ribarnica ribarnica);

        // Deletes a Ribarnica entity from the repository.
        void Delete(Ribarnica ribarnica);

        // Searches for Ribarnica entities based on a name value (vrednost).
        IQueryable<Ribarnica> PronadjiPoNazivu(string vrednost);
    }
}
