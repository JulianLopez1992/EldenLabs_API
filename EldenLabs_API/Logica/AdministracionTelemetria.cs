using CsvHelper;
using DAL;
using DAL.Entities;
using System.Globalization;

namespace BLL
{
    public class AdministracionTelemetria
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public AdministracionTelemetria(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }


        public List<Telemetria> ConsultarTelemetrias(DateTime? FechaInicial, DateTime? FechaFinal)
        {
            List<Telemetria> telemetrias = _applicationDbContext.Telemetrias.Where(w => w.EventProcessedUtcTime.Date <= FechaInicial && w.EventProcessedUtcTime.Date >= FechaFinal).ToList();
            return telemetrias;
        }


        public void CargarTelemetriaCSV(IFormFile file)
        {
            LeerCSV(file);
        }

        private void LeerCSV(IFormFile file)
        {
            var fileextension = Path.GetExtension(file.FileName);
            var filename = Guid.NewGuid().ToString() + fileextension;
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", filename);

            using (FileStream fs = File.Create(filepath))
            {
                file.CopyTo(fs);
            }
            if (fileextension == ".csv")
            {
                using (var reader = new StreamReader(filepath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {

                    List<Telemetria> records = new List<Telemetria>();
                    csv.Read();
                    csv.ReadHeader();
                    while (csv.Read())
                    {
                        var record = new Telemetria
                        {
                            ConnectionDeviceId = csv.GetField("ConnectionDeviceId"),
                            EventProcessedUtcTime = Convert.ToDateTime(csv.GetField("EventProcessedUtcTime")),
                            HefestoId = csv.GetField("HEFESTO_ID"),
                            TimeStamp = Convert.ToDateTime(csv.GetField("timestamp")).TimeOfDay,
                            VarName = csv.GetField("var-name"),
                            Value = Convert.ToInt32(csv.GetField("value")),
                            Puglin = csv.GetField("plugin"),
                            Request = csv.GetField("request"),
                            VarName1 = csv.GetField("var_name_1"),
                            Device = Convert.ToInt32(csv.GetField("device"))
                        };

                        records.Add(record);
                    }

                    _applicationDbContext.AddRange(records);
                    _applicationDbContext.SaveChanges();
                  
                }
            }

        }
    }
}
