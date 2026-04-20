using DTO.Shared;
using DTO.User;

namespace DAL.Interfaces;

public interface IUserRepository: IRepository<UserDto, CreateUserDto, UpdateUserDto>
{
    Task<ResponseWithFilterDto<UserDto>> GetAllWithFilter(QueryParamsDto queryParams);
    
    
}