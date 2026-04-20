using System.Linq.Dynamic.Core;
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using DTO.Booking;
using DTO.Event;
using DTO.Shared;
using DTO.User;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class UserRepository(ApplicationContext context):IUserRepository
{
    public async Task<List<UserDto>> GetAll()
    {
        List<User>users = await context.Users.ToListAsync();
        List<UserDto> userList = new List<UserDto>();
        foreach (var user in users)
        {
            UserDto userDto = new()
            {
                Id = user.Id,
                Email = user.Email,
                Phone = user.Phone,
                Password = user.Password,
                Patronymic = user.Patronymic,
                FirstName = user.FirstName,
                LastName = user.LastName,
                IsAdmin = user.IsAdmin,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt,
            };
            userList.Add(userDto);
        }
        return userList;
    }
    public async Task<ResponseWithFilterDto<UserDto>> GetAllWithFilter(QueryParamsDto queryParams)
    {
        int offset = int.Parse(queryParams.Offset);
        int limit = int.Parse(queryParams.Limit);
        string sorting = $"{queryParams.SortBy} {(queryParams.OrderBy?.ToLower() == "desc" ? "descending" : "ascending")}";
        var users = context
            .Users.AsQueryable();

        if (queryParams.Search != string.Empty)
        {
            users = users
                .Where(u => 
                    u.FirstName.ToLower().Contains(queryParams.Search.ToLower())
                    || u.LastName.ToLower().Contains(queryParams.Search.ToLower())
                    || u.Patronymic.ToLower().Contains(queryParams.Search.ToLower())
                    || u.Phone.ToLower().Contains(queryParams.Search.ToLower())
                    || u.Email.ToLower().Contains(queryParams.Search.ToLower())
                );
        }
        
        if (queryParams.IsAdmin)
        {
            users = users
                .Where(u => u.IsAdmin == queryParams.IsAdmin);
        }
        
        int TotalUsers = await users.CountAsync();

        var usersList = users
            .OrderBy(sorting)
            .Skip(offset * limit)
            .Take(limit)
            .Select(u => new UserDto()
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Patronymic = u.Patronymic,
                Phone = u.Phone,
                Email = u.Email,
                CreatedAt = u.CreatedAt,
                UpdatedAt = u.UpdatedAt
            })
            .ToList();

        return new ResponseWithFilterDto<UserDto>(
            usersList,
            queryParams.Offset,
            queryParams.Limit,
            TotalUsers
            );
    }

    public async Task<UserDto> GetById(Guid id)
    {
        User? user = await context.Users.FindAsync(id);

        return new UserDto()
        {
            Id = user.Id,
            Email = user.Email,
            Phone = user.Phone,
            Password = user.Password,
            Patronymic = user.Patronymic,
            FirstName = user.FirstName,
            LastName = user.LastName,
            IsAdmin = user.IsAdmin,
            CreatedAt = user.CreatedAt,
            UpdatedAt = user.UpdatedAt
        };
    }

    public async Task<UserDto> Create(CreateUserDto user)
    {
        User createdUser = new()
        {
            Email = user.Email,
            Phone = user.Phone,
            Password = user.Password,
            Patronymic = user.Patronymic,
            FirstName = user.FirstName,
            LastName = user.LastName,
            IsAdmin = user.IsAdmin,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
        context.Users.Add(createdUser);
        await context.SaveChangesAsync();

        return new UserDto()
        {
            Id = createdUser.Id,
            Email = createdUser.Email,
            Phone = createdUser.Phone,
            Password = createdUser.Password,
            Patronymic = createdUser.Patronymic,
            FirstName = createdUser.FirstName,
            LastName = createdUser.LastName,
            IsAdmin = createdUser.IsAdmin,
            CreatedAt = createdUser.CreatedAt,
            UpdatedAt = createdUser.UpdatedAt
        };
    }

    public async Task<UserDto> Update(UpdateUserDto user)
    {
        User? updatedUser = await context.Users.FindAsync(user.Id);
        updatedUser.Email = user.Email;
        updatedUser.Phone = user.Phone;
        updatedUser.Password = user.Password;
        updatedUser.Patronymic = user.Patronymic;
        updatedUser.FirstName = user.FirstName;
        updatedUser.LastName = user.LastName;
        updatedUser.IsAdmin = user.IsAdmin;
        updatedUser.UpdatedAt = DateTime.UtcNow;
        
        context.Users.Update(updatedUser);
        await context.SaveChangesAsync();

        return new UserDto()
        {
            Id = updatedUser.Id,
            Email = updatedUser.Email,
            Phone = updatedUser.Phone,
            Password = updatedUser.Password,
            Patronymic = updatedUser.Patronymic,
            FirstName = updatedUser.FirstName,
            LastName = updatedUser.LastName,
            IsAdmin = updatedUser.IsAdmin,
            CreatedAt = updatedUser.CreatedAt,
            UpdatedAt = updatedUser.UpdatedAt
        };
    }

    public async Task Delete(Guid id)
    {
        User? user = await context.Users.FindAsync(id);
        context.Users.Remove(user);
        await context.SaveChangesAsync();
    }
}