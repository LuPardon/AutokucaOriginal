using Autokuca.Service.Common;
using Autokuca.Model;
using Autokuca.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autokuca.Service
{

    public class Service:IService
    {
        private readonly IRepository _repository;

        public Service(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Salon>> GetAll(string? naziv)
        {
            return await _repository.GetAll(naziv);
        }
        public async Task<Salon> DohvatiSalon(int id)
        {
            return await _repository.DohvatiSalon(id);
        }

        public async Task<bool> AzurirajSalon(Salon Salon)
        {
            return await _repository.AzurirajSalon(Salon);
        }

        public async Task<bool> IzbrisiSalon(int SalonId)
        {
            return await _repository.IzbrisiSalon(SalonId);
        }

        public async Task<bool> NapraviSalon(Salon Salon)
        {
            return await _repository.NapraviSalon(Salon);
        }

        public async Task<IEnumerable<Vozilo>> DohvatiVozila(
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
            string? opis)
        {
            return await _repository.DohvatiVozila(
                id_salona: id_salona,
                proizvodac: proizvodac,
                model: model,
                vin: vin,
                godina: godina,
                snaga_motora: snaga_motora,
                id_tipVozila: id_tipVozila,
                id_gorivo: id_gorivo,
                id_mjenjac: id_mjenjac,
                id_oblik: id_oblik,
                opis: opis
                );
        }

        public async Task<Vozilo> DohvatiVozilo(int id)
        {
            return await _repository.DohvatiVozilo(id);
        }

        public async Task<bool> AzurirajVozilo(Vozilo Vozilo)
        {
            return await _repository.AzurirajVozilo(Vozilo);
        }

        public async Task<bool> IzbrisiVozilo(int VoziloId)
        {
            return await _repository.IzbrisiVozilo(VoziloId);
        }

        public async Task<bool> NapraviVozilo(Vozilo Vozilo)
        {
            return await _repository.NapraviVozilo(Vozilo);
        }
    }
}

