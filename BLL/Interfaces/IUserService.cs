using DTO.Shared;
using DTO.User;

namespace BLL.Interfaces;

public interface IUserService
{
    Task<List<UserDto>> GetUsers();
    Task<ResponseWithFilterDto<UserDto>> GetUsersWithFilter(QueryParamsDto queryParams);
    Task<UserDto> GetUser(Guid Id);
    Task<UserDto> CreateUser(CreateUserDto user);
    Task<UserDto> UpdateUser(UpdateUserDto user);
    Task DeleteUser(Guid Id);
}