using BackEnd.Domain.IRepositories;
using BackEnd.Domain.Models;
using BackEnd.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Persistence.Repositories
{
    public class CiudadRepository : ICiudadRepository
    {

        private readonly AplicationDbContext _context;

        public CiudadRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Ciudad> GetCiudadAsync(int idCiudad)
        {
            var ciudad = await _context.Ciudades.Where(x => x.Id == idCiudad).FirstOrDefaultAsync();
            return ciudad;
        }

        public async Task<List<Ciudad>> GetListCiudadesAsync()
        {
            var listaCiudad = await _context.Ciudades.Where(x => x.NombreCiudad != null).ToListAsync();
            return listaCiudad;
        }

        public async Task SavedCiudadAsync(Ciudad ciudad)
        {
            _context.Add(ciudad);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ValidateExistenceAsync(Ciudad ciudad)
        {
            var validateExistence = await _context.Ciudades.AnyAsync(x => x.NombreCiudad == ciudad.NombreCiudad);
            return validateExistence;
        }
    }
}
