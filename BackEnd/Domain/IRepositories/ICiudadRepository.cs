using BackEnd.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.Domain.IRepositories
{
    public interface ICiudadRepository
    {
        Task SavedCiudadAsync(Ciudad ciudad);
        Task<bool> ValidateExistenceAsync(Ciudad ciudad);
        Task<List<Ciudad>> GetListCiudadesAsync();
        Task<Ciudad> GetCiudadAsync(int idCiudad);
    }
}
