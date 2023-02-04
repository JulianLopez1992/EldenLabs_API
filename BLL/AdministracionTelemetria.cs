using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AdministracionTelemetria
    {
        //private readonly ApplicationDbContext _applicationDbContext;
        //public AdministracionTelemetria(ApplicationDbContext applicationDbContext)
        //{
        //    _applicationDbContext = applicationDbContext;
        //}


        public int CargarTelemetriaCSV() 
        {
            int resultado = 0;



            LeerCSV();
            //var usuario = _applicationDbContext.Usuarios.ToList();
            //_applicationDbContext.Telemetrias.ToList();

            return resultado;
        }

        private void LeerCSV() 
        {
            string ubicacionArchivo = "C:\\Users\\Julian\\Desktop\\Prueba Celsia\\Prueba tecnica Desarrollo\\DevOps I Lite\\Telemetria\\Telemetria\\000ddb06-dcc8-4bbb-acb8-d457f9f715e1.csv";
            StreamReader archivo = new StreamReader(ubicacionArchivo);



        }

    }
}
