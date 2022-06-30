using AutoMapper;
using reWrite.Models;
using reWrite.DTOs.Character;
using reWrite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using reWrite.Data;
using Microsoft.EntityFrameworkCore;

namespace reWrite.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public CharacterService(IMapper mapper,DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ResponseService<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            var responseService = new ResponseService<List<GetCharacterDto>>();
            var character = _mapper.Map<Character>(newCharacter);
            await _context.Characters.AddAsync(character);
            responseService.Data = await _context.Characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToListAsync();
            return responseService;
        }

        public async Task<ResponseService<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            var responseService = new ResponseService<List<GetCharacterDto>>();
            try
            {
                var character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);
                _context.Characters.Remove(character);
                responseService.Data = await _context.Characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToListAsync();
            }
            catch (Exception ex)
            {
                responseService.Success = false;
                responseService.Message = ex.Message;
            }
            responseService.Success = true;
            responseService.Message = "Deleting process is successful";
            return responseService;
        }

        public async Task<ResponseService<List<GetCharacterDto>>> GetAllCharacters()
        {
            var responseService = new ResponseService<List<GetCharacterDto>>();
            responseService.Data = await _context.Characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToListAsync();
            return responseService;
        }

        public async Task<ResponseService<GetCharacterDto>> GetCharacter(int id)
        {
            var responseService = new ResponseService<GetCharacterDto>();
            var character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);
            responseService.Data = _mapper.Map<GetCharacterDto>(character);
            return responseService;
        }

        public async Task<ResponseService<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateCharacter)
        {
            var responseService = new ResponseService<GetCharacterDto>();
            var character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == updateCharacter.Id);
            _mapper.Map<UpdateCharacterDto>(character);
            responseService.Data = _mapper.Map<GetCharacterDto>(updateCharacter);

            return responseService;
        }
    }
}