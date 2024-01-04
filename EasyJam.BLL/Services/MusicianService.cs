using EasyJam.BLL.DTO;
using EasyJamBLL.DTO;
using EasyJamDAL.Context;
using EasyJamDAL.Entities;
using EasyJamDAL.Entities.Enums;
using EasyJamDAL.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyJamBLL.Services
{
    public class MusicianService
    {
        private readonly EasyJamContext _context;

        public MusicianService(EasyJamContext context)
        {
            _context = context;
        } 

        public bool AddMusician(AddMusicianDTO add)
        {
            IMusicien m = new Musicien
            {
                Name = add.Name,
                Instrument1 = add.Instrument1,
                Instrument2 = add.Instrument2,
                Instrument3 = add.Instrument3,
                IsAvailable = add.IsAvailable,
            };
            if(_context.Musiciens.Any(ms => ms.Name == add.Name))
            {
                throw new ValidationException("nom deja existant");
            }
            _context.Add(m);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<MusicianDTO> GetAll()
        {
            return _context.Musiciens.Select(m => new MusicianDTO(m));
        }

        public MusicianDTO GetMusiById(int id)
        {
            Musicien? m = _context.Musiciens.FirstOrDefault(m => m.Id == id);
            if (m == null)
            {
                throw new KeyNotFoundException();
            }
            return new MusicianDTO(m);
        }

        public void Delete(int id)
        {
            IMusicien? musicien = _context.Musiciens.FirstOrDefault(u => u.Id == id);
            if (musicien == null)
            {
                throw new KeyNotFoundException();
            }
            _context.Remove(musicien);
            _context.SaveChanges();
        }

        public void EditMusi(EditMusiDTO edit, int id)
        {
            IMusicien? m = _context.Musiciens.FirstOrDefault(u => u.Id == id);
            if (m == null)
            {
                throw new KeyNotFoundException();
            }
            m.Instrument1 = edit.Instrument1;
            m.Instrument2 = edit.Instrument2;
            m.Instrument3 = edit.Instrument3;
            m.IsAvailable = edit.IsAvailable;
            _context.SaveChanges();
        }

        public void SwitchAvailability(int id)
        {
            IMusicien? m = _context.Musiciens.FirstOrDefault(mi => mi.Id == id);
            if (m == null)
            {
                throw new KeyNotFoundException();
            }
            m.IsAvailable = !m.IsAvailable;
            _context.SaveChanges();
        }

        public IEnumerable<MusicianDTO> GetGuitarMusi()
        {
            return GetAll().Where(m => m.Instrument1 == "Guitar" || m.Instrument2 == "Guitar" || m.Instrument3 == "Guitar");
        }
        public IEnumerable<MusicianDTO> GetBassMusi()
        {
            return GetAll().Where(m => m.Instrument1 == "Bass" || m.Instrument2 == "Bass" || m.Instrument3 == "Bass");
        }
        public IEnumerable<MusicianDTO> GetDrumMusi()
        {
            return GetAll().Where(m => m.Instrument1 == "Drum" || m.Instrument2 == "Drum" || m.Instrument3 == "Drum");
        }
        public IEnumerable<MusicianDTO> GetKeysMusi()
        {
            return GetAll().Where(m => m.Instrument1 == "Piano_Keys" || m.Instrument2 == "Piano_Keys" || m.Instrument3 == "Piano_Keys");
        }
        public IEnumerable<MusicianDTO> GetVoiceMusi()
        {
            return GetAll().Where(m => m.Instrument1 == "Voice" || m.Instrument2 == "Voice" || m.Instrument3 == "Voice");
        }
        public IEnumerable<MusicianDTO> GetOtherMusi()
        {
            return GetAll()
                .Where(m => m.Instrument1 != "Guitar" && m.Instrument1 != "Bass" && m.Instrument1 != "Drum" && m.Instrument1 != "Piano_Keys" && m.Instrument1 != "Voice" && m.Instrument1 != "" || m.Instrument2 != "Guitar" && m.Instrument2 != "Bass" && m.Instrument2 != "Drum" && m.Instrument2 != "Piano_Keys" && m.Instrument2 != "Voice" && m.Instrument2 != "" || m.Instrument3 != "Guitar" && m.Instrument3 != "Bass" && m.Instrument3 != "Drum" && m.Instrument3 != "Piano_Keys" && m.Instrument3 != "Voice" && m.Instrument3 != "");
        }
    }

}
