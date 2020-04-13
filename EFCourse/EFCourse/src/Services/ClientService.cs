using Microsoft.EntityFrameworkCore;
using Models;
using Persistence.Database;
using Services.QueryHelpers;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class ClientService
    {
        private readonly ApplicationDbContext _context;

        public ClientService(ApplicationDbContext context) 
        {
            _context = context;
        }

        public Client Get(int id) 
        {
            return _context.Clients.GetBaseQuery().SingleOrDefault(x => x.ClientId == id);
        }

        public Client GetFirstClient()
        {
            return _context.Clients.GetBaseQuery().FirstOrDefault();
        }

        public IEnumerable<Client> GetAll() 
        {
            return _context.Clients
                           .GetBaseQuery()
                           .OrderByDescending(x => x.ClientId)
                           .ToList();
        }
    }
}
