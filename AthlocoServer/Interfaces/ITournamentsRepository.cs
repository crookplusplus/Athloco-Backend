using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AthlocoServer.Models;

namespace AthlocoServer.Interfaces
{
    public interface ITournamentsRepository
    {
        Task<List<Tournaments>> GetAllAsync();
    }
}