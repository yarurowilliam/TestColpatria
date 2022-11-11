using BackEnd.Domain.IRepositories;
using BackEnd.Domain.IServices;
using BackEnd.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.Services
{
    public class PolizaService : IPolizaService
    {
        private readonly IPolizaRepository _polizaRepository;
        private readonly ICiudadRepository _ciudadRepository;

        public PolizaService(IPolizaRepository polizaRepository, ICiudadRepository ciudadRepository)
        {
            _polizaRepository = polizaRepository;
            _ciudadRepository = ciudadRepository;
        }

        public async Task<Poliza> GetPolizaAsync(string placaVehiculo)
        {
            return await _polizaRepository.GetPolizaAsync(placaVehiculo);
        }

        public async Task<List<Poliza>> GetListPolizasAsync()
        {
            return await _polizaRepository.GetListPolizasAsync();
        }

        public async Task<string> SavedPolizaAsync(Poliza poliza)
        {
            var result = string.Empty;
            var ciudad = await _ciudadRepository.GetCiudadAsync(poliza.IDCiudad);
            var polizaAntigua = await _polizaRepository.GetPolizaAsync(poliza.PlacaVehiculo);
    
            if(ciudad != null)
			{
                if(polizaAntigua != null)
				{
                    if(polizaAntigua.VencimientoPoliza < poliza.FechaInicio)
					{
                        await _polizaRepository.ActualizarPolizaAsync(poliza);
                        result = "La poliza se actualizo correctamente, puede volver a consultar...";
					}
					else
					{
                        result = "La póliza solo se podrá vender en un periodo no máximo a la fecha de vencimiento de la póliza actual.";
                    }
				}
				else
				{
                    await _polizaRepository.SavedPolizaAsync(poliza);
                    result = "La poliza se registro correctamente!";
                }
			}
			else
			{
                result = "La ciudad que intenta ingresar no esta permitida...";
			}
            return result;
        }
	}
}
