﻿using Application.DaoInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared.DTOs;
using Shared.Models;

namespace EfcDataAccess.DAOs;

public class UserEfcDao : IUserDao
{
    private readonly TodoContext context;

    public UserEfcDao(TodoContext context)
    {
        this.context = context;
    }

    public async Task<User> CreateAsync(User user)
    {
        EntityEntry<User> newUser = await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return newUser.Entity;
        /*throw new NotImplementedException();*/
    }

    public async Task<User?> GetByUsernameAsync(string userName)
    {
        /*throw new NotImplementedException();*/
        User? existing = await context.Users.FirstOrDefaultAsync(u =>
            u.UserName.ToLower().Equals(userName.ToLower())
        );
        return existing;
    }

    public async Task<IEnumerable<User>> GetAsync(SearchUserParametersDto searchParameters)
    {
        /*throw new NotImplementedException();*/
        IQueryable<User> usersQuery = context.Users.AsQueryable();
        if (searchParameters.UsernameContains != null)
        {
            usersQuery = usersQuery.Where(u =>
                u.UserName.ToLower().Contains(searchParameters.UsernameContains.ToLower()));
        }

        IEnumerable<User> result = await usersQuery.ToListAsync();
        return result;
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        User? user = await context.Users.FindAsync(id);
        return user;
    }
}