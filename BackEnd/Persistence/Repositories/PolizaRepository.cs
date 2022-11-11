using BackEnd.Domain.IRepositories;
using BackEnd.Domain.Models;
using BackEnd.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Persistence.Repositories
{
    public class PolizaRepository : IPolizaRepository
    {

        private readonly AplicationDbContext _context;

        public PolizaRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Poliza> GetPolizaAsync(string placaVehiculo)
        {
            var poliza = await _context.Polizas.Where(x => x.PlacaVehiculo == placaVehiculo).FirstOrDefaultAsync();
            return poliza;
        }

        public async Task<List<Poliza>> GetListPolizasAsync()
        {
            var listaPoliza = await _context.Polizas.Where(x => x.PlacaVehiculo != null).ToListAsync();
            return listaPoliza;
        }

        public async Task SavedPolizaAsync(Poliza poliza)
        {
            _context.Add(poliza);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarPolizaAsync(Poliza poliza)
        {
            _context.Update(poliza);
            await _context.SaveChangesAsync();
        }
    }
}
