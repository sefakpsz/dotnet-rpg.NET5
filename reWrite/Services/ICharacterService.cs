using reWrite.Models;
using reWrite.DTOs.Character;
using reWrite.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace reWrite.Services
{
    public interface ICharacterService
    {
        Task<ResponseService<List<GetCharacterDto>>> GetAllCharacters();
        Task<ResponseService<GetCharacterDto>> GetCharacter(int id);
        Task<ResponseService<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter);
        Task<ResponseService<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateCharacter);
        Task<ResponseService<List<GetCharacterDto>>> DeleteCharacter(int id);
    }
}
