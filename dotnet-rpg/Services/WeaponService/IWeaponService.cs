﻿using dotnet_rpg.DTOs.Character;
using dotnet_rpg.DTOs.Weapon;
using dotnet_rpg.Models;
using System.Threading.Tasks;

namespace dotnet_rpg.Services.WeaponService
{
    public interface IWeaponService
    {
        Task<ServiceResponse<GetCharacterDto>> AddWeapon(AddWeaponDto newWeapon);
    }
}