using DAL;
using DAL.Entities;

namespace EldenLabs_API.Logica
{
    public class AdministracionUsuarios
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public AdministracionUsuarios(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }


        public bool Login(Usuario usuario) 
        { 
            bool acceso = false;
            Usuario usuarioLogin = _applicationDbContext.Usuarios.Where(w => w.Nombre == usuario.Nombre && w.Password == usuario.Password && w.Estado == true).FirstOrDefault();

            acceso = usuario == null ? false : true;

            return acceso;

        }
    }
}
