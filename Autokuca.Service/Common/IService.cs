using Autokuca.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autokuca.Service.Common
{
    public interface IService
    {
        Task<IEnumerable<Salon>> GetAll(string? naziv);
        Task<Salon> DohvatiSalon(int id);

        Task<bool> AzurirajSalon(Salon Salon);

        Task<bool> IzbrisiSalon(int SalonId);

        Task<bool> NapraviSalon(Salon Salon);

        Task<IEnumerable<Vozilo>> DohvatiVozila(
            int? id_salona,
            string? proizvodac,
            string? model,
            string? vin,
            short? godina,
            short? snaga_motora,
            int? id_tipVozila,
            int? id_gorivo,
            int? id_mjenjac,
            int? id_oblik,
            string? opis
            );
        Task<Vozilo> DohvatiVozilo(int id);

        Task<bool> AzurirajVozilo(Vozilo Vozilo);

        Task<bool> IzbrisiVozilo(int VoziloId);

        Task<bool> NapraviVozilo(Vozilo Vozilo);
        Task<ApplicationUser> DohvatiUser(string idUser);
        Task<List<ApplicationUser>> GetApplicationUsers(string mail, string lozinka);
    }
}
