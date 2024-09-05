using Autokuca.DAL;
using Autokuca.Model;
using Autokuca.Repository.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autokuca.Repository
{
    public class Repository:IRepository
    {
        private readonly DataContext _context;
        public Repository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> AzurirajSalon(Salon Salon)
        {
            try
            {
                var existing = await _context.Salons.FindAsync(Salon.SalonId);

                if (existing == null)
                {
                    return false;
                }

                existing.Naziv = Salon.Naziv;


                _context.ChangeTracker.DetectChanges();
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> AzurirajVozilo(Vozilo Vozilo)
        {
            try
            {
                var existing = await _context.Vozilos.FindAsync(Vozilo.VoziloId);

                if (existing == null)
                {
                    return false;
                }

                existing.SalonId = Vozilo.SalonId;
                existing.Proizvodac = Vozilo.Proizvodac;
                existing.Model = Vozilo.Model;
                existing.Godina = Vozilo.Godina;
                existing.SnagaMotora = Vozilo.SnagaMotora;
                existing.TipVozilaId = Vozilo.TipVozilaId;
                existing.GorivoId = Vozilo.GorivoId;
                existing.MjenjacId = Vozilo.MjenjacId;
                existing.OblikId = Vozilo.OblikId;
                existing.Opis = Vozilo.Opis;
                
                _context.ChangeTracker.DetectChanges();
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Salon> DohvatiSalon(int id)
        {
            try
            {
                var task = await _context.Salons.FirstOrDefaultAsync(t => t.SalonId == id);
                return (task is null) ? null : task;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<ApplicationUser>> GetApplicationUsers(string mail, string lozinka)
        {
            try
                {
                    var query = _context.Users.AsQueryable();
                    if (!string.IsNullOrEmpty(mail))
                    {
                        query = query.Where(s =>
                        s.Email != null &&
                        s.Email.Contains(mail));
                    }

                    return await query.ToListAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
        }

        public async Task<ApplicationUser> DohvatiUser(string idUser)
        {
            try
            {
                var task = await _context.Users.FirstOrDefaultAsync(t => t.Id == idUser );
                return (task is null) ? null : task;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
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
            string? opis
            )
        {
            try
            {
                var query = _context.Vozilos.AsQueryable();

                if (id_salona.HasValue)
                {
                    query = query.Where(v => v.SalonId == id_salona);
                }

                if (!string.IsNullOrEmpty(proizvodac))
                {
                    query = query.Where(s =>
                    s.Proizvodac != null &&
                    s.Proizvodac.Contains(proizvodac));
                }

                if (!string.IsNullOrEmpty(model))
                {
                    query = query.Where(s =>
                    s.Model != null &&
                    s.Model.Contains(model));
                }

                if (!string.IsNullOrEmpty(vin))
                {
                    query = query.Where(s =>
                    s.Vin != null &&
                    s.Vin.Contains(vin));
                }

                if (godina.HasValue)
                {
                    query = query.Where(v => v.Godina == godina);

                }

                if (snaga_motora.HasValue)
                {
                    query = query.Where(v => v.SnagaMotora == snaga_motora);
                }

                if (id_tipVozila.HasValue)
                {
                    query = query.Where(v => v.TipVozilaId == id_tipVozila);
                }

                if (id_gorivo.HasValue)
                {
                    query = query.Where(v => v.GorivoId == id_gorivo);
                }

                if (id_mjenjac.HasValue)
                {
                    query = query.Where(v => v.MjenjacId == id_mjenjac);
                }

                if (id_oblik.HasValue)
                {
                    query = query.Where(v => v.OblikId == id_oblik);
                }

                if (!string.IsNullOrEmpty(opis))
                {
                    query = query.Where(s =>
                    s.Opis != null &&
                    s.Opis.Contains(opis));
                }


                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Vozilo> DohvatiVozilo(int id)
        {
            try
            {
                var vozilo = await _context.Vozilos.FirstOrDefaultAsync(t => t.VoziloId == id);
                return (vozilo is null) ? null : vozilo;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<Salon>> GetAll(
            string? naziv)
        {
            try
            {
                var query = _context.Salons.AsQueryable();
                if (!string.IsNullOrEmpty(naziv))
                {
                    query = query.Where(s =>
                    s.Naziv != null &&
                    s.Naziv.Contains(naziv));
                }

                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> IzbrisiSalon(int SalonId)
        {
            try
            {
                var existing = await _context.Salons.FindAsync(SalonId);

                if (existing is null)
                {
                    return false;
                }

                _context.Salons.Remove(existing);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> IzbrisiVozilo(int VoziloId)
        {
            try
            {
                var existing = await _context.Vozilos.FindAsync(VoziloId);

                if (existing is null)
                {
                    return false;
                }

                _context.Vozilos.Remove(existing);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> NapraviSalon(Salon Salon)
        {
            try
            {
                await _context.Salons.AddAsync(Salon);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> NapraviVozilo(Vozilo Vozilo)
        {
            try
            {
                await _context.Vozilos.AddAsync(Vozilo);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
