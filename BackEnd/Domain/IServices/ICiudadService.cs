using BackEnd.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.Domain.IServices
{
    public interface ICiudadService
    {
        Task SavedCiudadAsync(Ciudad ciudad);
        Task<bool> ValidateExistenceAsync(Ciudad ciudad);
        Task<List<Ciudad>> GetListCiudadesAsync();
        Task<Ciudad> GetCiudadAsync(int idCiudad);
    }
}
