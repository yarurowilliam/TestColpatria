using BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Domain.IServices
{
    public interface IUsuarioService
    {
        Task SavedUser(Usuario usuario);
        Task<bool> ValidateExistence(Usuario usuario);
        Task<Usuario> ValidatePassword(int idUsuario, string passwordAnterior);
        Task UpdatePassword(Usuario usuario);
        Task<List<Usuario>> GetListUsuarios();
        Task<Usuario> GetUsuario(int id);
        Task UpdateRol(Usuario usuario);
    }
}
