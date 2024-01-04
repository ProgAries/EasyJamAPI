using EasyJamBLL.DTO;
using EasyJamBLL.Services;
using EasyJamDAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EasyJamAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicianController : ControllerBase
    {
        private readonly MusicianService _service;
        private readonly JamService _jamService;

        public MusicianController(MusicianService service, JamService jamService)
        {
            _service = service;
            _jamService = jamService;
        }

        [HttpGet]
        public IActionResult GetMusi()
        {
            return Ok(_service.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult GetMusicianById(int id)
        {
            return Ok(_service.GetMusiById(id));
        }

        [HttpGet("guitarist")]
        public IActionResult GetGuitarist()
        {
            return Ok(_service.GetGuitarMusi());
        }

        [HttpGet("bassist")]
        public IActionResult GetBassist()
        {
            return Ok(_service.GetBassMusi());
        }

        [HttpGet("drummer")]
        public IActionResult GetDrummer()
        {
            return Ok(_service.GetDrumMusi());
        }
        [HttpGet("pianist")]
        public IActionResult GetPianist()
        {
            return Ok(_service.GetKeysMusi());
        }
        [HttpGet("singer")]
        public IActionResult GetSinger()
        {
            return Ok(_service.GetVoiceMusi());
        }
        [HttpGet("other")]
        public IActionResult GetOther()
        {
            return Ok(_service.GetOtherMusi());
        }



        [HttpPost]
        public IActionResult AddMusician(AddMusicianDTO add)
        {
            _service.AddMusician(add);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _service.Delete(id);
                return Ok();
            }
            catch (KeyNotFoundException)
            {

                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Edit(EditMusiDTO edit, int id)
        {
            _service.EditMusi(edit, id);
            return Ok(edit);
        }

        [HttpPut("switch/{id}")]
        public IActionResult SwitchAvailability(int id)
        {
            try
            {
                _service.SwitchAvailability(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Errore durante il cambio di stato della sessione: {ex.Message}");
            }
        }

    }
}
