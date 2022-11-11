using BackEnd.Domain.IRepositories;
using BackEnd.Domain.IServices;
using BackEnd.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.Services
{
    public class CiudadService : ICiudadService
    {
        private readonly ICiudadRepository _ciudadRepository;

        public CiudadService(ICiudadRepository ciudadRepository)
        {
            _ciudadRepository = ciudadRepository;
        }

		public async Task SavedCiudadAsync(Ciudad ciudad)
		{
			await _ciudadRepository.SavedCiudadAsync(ciudad);
		}

		public async Task<bool> ValidateExistenceAsync(Ciudad ciudad)
		{
			return await _ciudadRepository.ValidateExistenceAsync(ciudad);
		}

        public async Task<List<Ciudad>> GetListCiudadesAsync()
		{
			return await _ciudadRepository.GetListCiudadesAsync();
		}

        public async Task<Ciudad> GetCiudadAsync(int idCiudad)
		{
			return await _ciudadRepository.GetCiudadAsync(idCiudad);
		}
	}
}
