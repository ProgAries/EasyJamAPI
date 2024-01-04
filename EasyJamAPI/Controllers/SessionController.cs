using EasyJamBLL.Services;
using EasyJamBLL.DTO;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace EasyJamAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {

        private readonly MusicianService _service;
        private readonly JamService _jamService;

        public SessionController(MusicianService service, JamService jamService)
        {
            _service = service;
            _jamService = jamService;
        }

        [HttpGet]
        public IActionResult GetJam()
        {
            return Ok(_jamService.GetAll());
        }
        [HttpGet("chords")]
        public IActionResult GetChords()
        {
            return Ok(_jamService.GetChords());
        }

        [HttpGet("checkOnStage")]
        public ActionResult<bool> CheckIfSessionOnStage()
        {

            return _jamService.CheckIfSessionOnStage();
        }

        [HttpGet("{id}")]
        public IActionResult GetSessionById(int id) 
        {
            return Ok(_jamService.GetSessionById(id));
        }

        [HttpPost]
        public IActionResult AddJam(AddJamDTO add)
        {
            try
            {
                _jamService.AddJam(add);
            }
            catch (ValidationException ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPost("chord")]
        public IActionResult AddChord(AddChordDTO chord)
        {
            try
            {
                _jamService.AddChord(chord);
            }
            catch(ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Edit(EditJamDTO edit, int id)
        {
            _jamService.EditJam(edit, id);
            return Ok(edit);
        }

        [HttpPut("start/{id}")]
        public IActionResult ChangeStateToStart(int id)
        {
            if (!_jamService.SessionExists(id))
            {
                return NotFound();
            }

            try
            {
                _jamService.ChangeSessionStateToStart(id);
                var updatedSession = _jamService.GetSessionById(id);

                return Ok(updatedSession);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Errore durante il cambio di stato della sessione: {ex.Message}");
            }
        }

        [HttpPut("end/{id}")]
        public IActionResult ChangeStateToEnd(int id, int minutes, int seconds)
        {
            if (!_jamService.SessionExists(id))
            {
                return NotFound();
            }

            try
            {
                _jamService.ChangeSessionStateToEnd(id, minutes, seconds);
                var updatedSession = _jamService.GetSessionById(id);
                return Ok(updatedSession);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Errore durante il cambio di stato della sessione: {ex.Message}");
            }
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteSession(int id)
        {
            if (!_jamService.SessionExists(id))
            {
                return NotFound();
            }

            try
            {
                _jamService.DeleteJam(id);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Errore durante l'eliminazione della sessione: {ex.Message}");
            }
        }

        [HttpDelete("all")]
        public IActionResult DeleteAllFinish() 
        {

            try
            {
                _jamService.DeleteAllFinished();
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Errore durante l'eliminazione della sessione: {ex.Message}");
            }

        }


    }
}
