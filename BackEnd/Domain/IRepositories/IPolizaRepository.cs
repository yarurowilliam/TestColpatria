using BackEnd.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.Domain.IRepositories
{
    public interface IPolizaRepository
    {
        Task SavedPolizaAsync(Poliza poliza);
        Task<List<Poliza>> GetListPolizasAsync();
        Task<Poliza> GetPolizaAsync(string placaVehiculo);
        Task ActualizarPolizaAsync(Poliza poliza);
    }
}
