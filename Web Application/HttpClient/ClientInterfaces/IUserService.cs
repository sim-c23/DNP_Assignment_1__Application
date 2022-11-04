﻿using Shared.DTOs;
using Shared.Models;

namespace HttpClient.ClientInterfaces;

public interface IUserService
{
    Task<User> Create(UserCreationDto dto);
    
    Task<IEnumerable<User>> GetUsers(string? usernameContains = null);
}