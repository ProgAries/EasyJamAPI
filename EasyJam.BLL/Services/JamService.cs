using EasyJamBLL.DTO;
using EasyJamDAL.Context;
using EasyJamDAL.Entities;
using EasyJamDAL.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyJamBLL.Services
{
    public class JamService
    {
        private readonly EasyJamContext _context;

        public JamService(EasyJamContext context)
        {
            _context = context;
        }

        public IEnumerable<JamDTO> GetAll()
        {
            return _context.Jams.Select(j => new JamDTO(j));
        }

        public IEnumerable<ChordsDTO> GetChords()
        {
            return _context.Chords.Select(c => new ChordsDTO(c));
        }

        public JamDTO GetSessionById(int id)
        {
            JamSession? jam = _context.Jams.FirstOrDefault(j => j.Id == id);
            if (jam == null)
            {
                throw new KeyNotFoundException();
            }

            return new JamDTO(jam);
        }

        public bool AddJam(AddJamDTO add)
        {
            
            JamSession j = new JamSession
            {
                Mic1 = add.Mic1,
                Mic2 = add.Mic2,
                Drum = add.Drum,
                Bass = add.Bass,
                Gtr1 = add.Gtr1,
                Gtr2 = add.Gtr2,
                Keys = add.Keys,
                Other1 = add.Other1,
                Other2 = add.Other2,
                Other3 = add.Other3,
                IsRandom = add.IsRandom,
            };
            
            j.Name = "Session " + j.Id.ToString();
            j.State = SessionState.pending;
            _context.Add(j);
            _context.SaveChanges();
            return true;
        }

        public bool AddChord(AddChordDTO add)
        {
            ChordProgression c = new ChordProgression
            {
                Chord = add.Chord
            };
            _context.Add(c);
            _context.SaveChanges();
            return true;
        }
        

        public void DeleteJam(int id)
        {
            JamSession? jam = _context.Jams.FirstOrDefault(j => j.Id == id);
            if (jam == null || jam.State == SessionState.on_stage)
            {
                throw new KeyNotFoundException();
            }
            _context.Remove(jam);
            _context.SaveChanges();
        }

        public void DeleteAllFinished()
        {
            bool isPresent = false;
            JamSession? jam = _context.Jams.FirstOrDefault(j => j.State == SessionState.finished);
            if (jam != null)
            {
                isPresent = true;
                while (isPresent)
                {
                    _context.Remove(jam);
                    _context.SaveChanges();
                    jam = _context.Jams.FirstOrDefault(j => j.State == SessionState.finished);
                    if (jam == null)
                    {
                        isPresent = false;
                    }
                }
            }
            else
            {
                throw new KeyNotFoundException();
            }

        }

        public void EditJam(EditJamDTO edit, int id)
        {
            JamSession? j = _context.Jams.FirstOrDefault(u => u.Id == id);
            if (j == null)
            {
                throw new KeyNotFoundException();
            }
            j.Mic1 = edit.Mic1;
            j.Mic2 = edit.Mic2;
            j.Drum = edit.Drum;
            j.Bass = edit.Bass;
            j.Gtr1 = edit.Gtr1;
            j.Gtr2 = edit.Gtr2;
            j.Keys = edit.Keys;
            j.Other1 = edit.Other1;
            j.Other2 = edit.Other2;
            j.Other3 = edit.Other3;
            _context.SaveChanges();
        }

        public void ChangeSessionStateToStart(int id) 
        { 
            JamSession? js = _context.Jams.FirstOrDefault(j => j.Id == id);
            if(js == null)
            {
                throw new KeyNotFoundException("This session not exist");
            }
            if (_context.Jams.Any(j => j.State == SessionState.on_stage))
            {
                throw new InvalidOperationException("Another session is already on stage. Wait for it to finish.");
            }
            js.State = SessionState.on_stage;
            _context.SaveChanges();
        }

        public bool CheckIfSessionOnStage() {
            if (_context.Jams.Any(j => j.State == SessionState.on_stage))
            {
                return true;
            }

            return false; 
        }

        public void ChangeSessionStateToEnd(int id, int minutes, int seconds)
        {
            JamSession? js = _context.Jams.FirstOrDefault(j => j.Id == id);
            if (js == null)
            {
                throw new KeyNotFoundException();
            }
            string m = minutes.ToString();
            string s = seconds.ToString();
            js.SessionTime = m + ':' + s;
            js.State = SessionState.finished;
            _context.SaveChanges();
        }

        public bool SessionExists(int sessionId)
        {
            var session = GetSessionById(sessionId);
            return session != null;
        }

    }
}
