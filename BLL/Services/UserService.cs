using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using DTO.Shared;
using DTO.User;

namespace BLL.Services;

public class UserService(IUserRepository userRepository):IUserService
{
    public async Task<List<UserDto>> GetUsers() => await userRepository.GetAll();
    public Task<ResponseWithFilterDto<UserDto>> GetUsersWithFilter(QueryParamsDto queryParams) => userRepository.GetAllWithFilter(queryParams);
    public async Task<UserDto> GetUser(Guid Id) => await userRepository.GetById(Id);
    public async Task<UserDto> CreateUser(CreateUserDto user) => await userRepository.Create(user);
    public async Task<UserDto> UpdateUser(UpdateUserDto user) => await userRepository.Update(user);
    public async Task DeleteUser(Guid Id) => await userRepository.Delete(Id);
}