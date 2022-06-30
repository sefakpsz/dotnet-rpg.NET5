using Microsoft.AspNetCore.Mvc;
using reWrite.DTOs.Character;
using reWrite.Models;
using reWrite.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace reWrite.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ResponseService<List<GetCharacterDto>>>> Get()
        {
            return Ok(await _characterService.GetAllCharacters());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseService<GetCharacterDto>>> GetCharacter(int id)
        {
            return Ok(await _characterService.GetCharacter(id));
        }

        [HttpDelete]
        public async Task<ActionResult<ResponseService<List<GetCharacterDto>>>> DeleteCharacter(int id)
        {
            return Ok(await _characterService.DeleteCharacter(id));
        }

        [HttpPut]
        public async Task<ActionResult<ResponseService<GetCharacterDto>>> UpdateCharacter(UpdateCharacterDto updateCharacter)
        {
            return Ok(await _characterService.UpdateCharacter(updateCharacter));
        }

        [HttpPost]
        public async Task<ActionResult<ResponseService<List<GetCharacterDto>>>> AddCharacter(AddCharacterDto newCharacter)
        {
            return Ok(await _characterService.AddCharacter(newCharacter));
        }
    }
}