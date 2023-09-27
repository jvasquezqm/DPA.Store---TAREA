using DPA.Store.DOMAIN.Core.Entities;
using System.ComponentModel;

namespace DPA.Store.DOMAIN.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> RegisterUser(User user);  //llama a un metodo para usar
        Task<bool> Login(String correo , String Password);  //llama a un metodo para usar
        Task<bool> Eliminar(int id);  //llama a un metodo para usar
    }
}