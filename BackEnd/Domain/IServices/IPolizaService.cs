using BackEnd.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.Domain.IServices
{
    public interface IPolizaService
    {
        Task<string> SavedPolizaAsync(Poliza poliza);
        Task<List<Poliza>> GetListPolizasAsync();
        Task<Poliza> GetPolizaAsync(string placaVehiculo);
    }
}
